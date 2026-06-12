
using System.Net.Mail;

public class OrderProcessor
{
    public string ProcessOrder(int schoolId, List<OrderLine> lines, string parentEmail)
    {
        var conn = new SqlConnection(ConfigurationManager.AppSettings["DbConn"]);
        conn.Open();

        var cmd = new SqlCommand(
            "SELECT TierCode FROM Schools WHERE Id = " + schoolId,
            conn);

        var tier = (string)cmd.ExecuteScalar();

        if (tier == null)
            return "FAIL: school not found";

        decimal subtotal = 0;

        foreach (var line in lines)
        {
            var priceCmd = new SqlCommand(
                "SELECT BasePrice FROM Products WHERE Sku = '" + line.Sku + "'",
                conn);

            decimal price = (decimal)priceCmd.ExecuteScalar();

            if (tier == "GOLD")
                price *= 0.85m;
            else if (tier == "SILVER")
                price *= 0.92m;

            if (!string.IsNullOrEmpty(line.Embroidery))
            {
                if (line.Embroidery.Length <= 3)
                    price += 4.50m;
                else
                    price += 8.00m;
            }

            var stockCmd = new SqlCommand(
                "SELECT Qty FROM Stock WHERE Sku = '" + line.Sku + "'",
                conn);

            int stock = (int)stockCmd.ExecuteScalar();

            if (stock < line.Quantity)
                return "FAIL: out of stock " + line.Sku;

            subtotal += price * line.Quantity;
        }

        var http = new HttpClient();
        var body = "amount=" + subtotal + "&email=" + parentEmail;

        var payRes = http
            .PostAsync(
                "https://api.paymentprovider.com/intents",
                new StringContent(body))
            .Result;

        if (!payRes.IsSuccessStatusCode)
            return "FAIL: payment";

        try
        {
            var smtp = new SmtpClient(ConfigurationManager.AppSettings["SmtpHost"]);

            smtp.Send(
                "orders@brindleford.co.uk",
                parentEmail,
                "Order confirmed",
                "Your order total is £" + subtotal);
        }
        catch
        {
            // swallow
        }

        return "OK";
    }
}

public class OrderLine
{
    public string Sku { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string? Embroidery { get; set; }
}