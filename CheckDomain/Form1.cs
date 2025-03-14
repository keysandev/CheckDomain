using System.DirectoryServices.ActiveDirectory;
using System.Net.Sockets;
using System.Text;

namespace CheckDomain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChecker_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string msgResult = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                string whoisServer = "whois.iana.org";

                try
                {
                    // ?????? ???? whois ????? ???? TLD ?? IANA
                    string tldWhoisServer = GetWhoisServerForTld(whoisServer, url, ref msgResult);

                    if (tldWhoisServer != null)
                    {
                        // ????? ??????? whois ?? ???? whois ?????
                        string whoisResult = GetWhoisInformation(tldWhoisServer, url, ref msgResult);
                        if (IsDomainRegistered(whoisResult))
                        {
                            StringBuilder sb =new StringBuilder();
                            sb.AppendLine($"Domain is registered.");
                            sb.AppendLine(whoisResult);
                            txtPreview.Text = sb.ToString();

                        }
                        else
                        {
                            txtPreview.Text = "Domain is not registered.";
                        }
                    }
                    else
                    {
                        txtPreview.Text = "Could not find the appropriate WHOIS server.";
                    }
                }
                catch (Exception ex)
                {
                    // ????? ????? ??? ?? ???? ???? ????
                    txtPreview.Text = $"An error occurred: {ex.Message}";
                }
            }
        }

        static string GetWhoisServerForTld(string whoisServer, string domain, ref string msgRexult)
        {
            string tld = domain.Substring(domain.LastIndexOf('.') + 1);

            try
            {
                using (TcpClient client = new TcpClient(whoisServer, 43))
                using (NetworkStream networkStream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(networkStream, Encoding.ASCII))
                using (StreamReader reader = new StreamReader(networkStream, Encoding.ASCII))
                {
                    // ????? ??????? TLD ?? IANA
                    writer.WriteLine(tld);
                    writer.Flush();

                    string response = reader.ReadToEnd();

                    // ?????? ???? whois ?? ????
                    var lines = response.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("whois:"))
                        {
                            return line.Substring(6).Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msgRexult = $"An error occurred while getting WHOIS server for TLD: {ex.Message}";
            }

            return null;
        }

        static string GetWhoisInformation(string whoisServer, string domain, ref string msgResult)
        {
            try
            {
                using (TcpClient client = new TcpClient(whoisServer, 43))
                using (NetworkStream networkStream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(networkStream, Encoding.ASCII))
                using (StreamReader reader = new StreamReader(networkStream, Encoding.ASCII))
                {
                    // ????? ??? ????? ?? ???? whois
                    writer.WriteLine(domain);
                    writer.Flush();

                    // ?????? ???? ?? ???? whois
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred while getting WHOIS information: {ex.Message}";
            }
        }

        static bool IsDomainRegistered(string whoisResponse)
        {
            // ????? ???? whois ???? ????? ?????? ?????????? ??? ???? ?????
            string[] notRegisteredKeywords = {
                "No match for", "Domain not found", "No entries found",
                "NOT FOUND", "Status: free", "No Data Found", "No Object Found"
            };

            foreach (var keyword in notRegisteredKeywords)
            {
                if (whoisResponse.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    return false; // ????? ??? ???? ???
                }
            }

            return true; // ????? ??? ??? ???
        }

    }
}
