///// Mohammad Heydari /////////
////// Shamsipour Technical and Vocational College (2023) //////////////


using System.Collections;
using System.Data;
using System.Xml.Linq;
using tamrin8API;

Calculation calculation = new Calculation();
API.ChangeDefault();
int input;
string output;

var Data = await ReadAPI.ReadAPI1();
DateTime t = DateTime.Now;
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Digital currency used: {0}\n The highest price: {1}\n The lowest price : {2}\n Last price: {3}\nNow:{4}"
    , Data.symbol, Data.high, Data.low, Data.last, t);
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("******************");
Console.ResetColor();
do
{
    Console.WriteLine();
    Console.WriteLine("Please enter your number wanted:\n(1 => Prediction accuracy test.2 =>  Possible price of Bitcoin for tomorrow.3 => Price prediction in a certain period of time:)");
    if (int.TryParse(Console.ReadLine(), out input) == true)
    {
        switch (input)
        {
            case 2:
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                DateTime time4 = DateTime.Now;
                Console.WriteLine($"Possible price tomorrow:" + calculation.PriceCalculation() + "******now:" + time4);
                Console.ResetColor();
                break;

            case 1:
                Console.WriteLine("Please enter max price:");
                double max;
                if (double.TryParse(Console.ReadLine(), out max) == true)
                {
                    Console.WriteLine("Please enter min price:");
                    double min;
                    if (double.TryParse(Console.ReadLine(), out min) == true)
                    {

                        Console.WriteLine();
                        Console.WriteLine("Possible price tomorrow:" + calculation.PriceCalculation2(max, min));
                    }
                    else { Console.WriteLine("Error"); }
                }
                else
                {
                    Console.WriteLine("Error");
                }
                break;

            case 3:
                do
                {
                    string URL = "https://api.kucoin.com/api/v1/market/stats?symbol=BTC-USDT";
                    double[] doubles = new double[60];
                    for (int i = 0; i <= 59; i++)
                    {

                        using (HttpResponseMessage response1 = await API.Client.GetAsync(URL))
                        {

                            if (response1.IsSuccessStatusCode)
                            {
                                DataAPI pricenow = await response1.Content.ReadAsAsync<DataAPI>();
                                doubles[i] = Convert.ToDouble(pricenow.data.last);
                                DateTime time5 = DateTime.Now;
                                Console.WriteLine();
                                Console.WriteLine(doubles[i] + ")******(" + time5);
                            }
                        }
                        Thread.Sleep(58000);
                    }
                    Console.WriteLine();
                    double x = doubles[0];
                    double y = doubles[59];
                    double price = calculation.PriceCalculation3(x, y);
                    DateTime time3 = DateTime.Now;
                    Console.WriteLine("The price of the next few hours(May be the maximum price of the day): " + price + "*****now:" + time3);


                    double[] doubles2 = new double[1];
                    Thread.Sleep(3600001);

                    using (HttpResponseMessage response2 = await API.Client.GetAsync(URL))
                    {

                        if (response2.IsSuccessStatusCode)
                        {
                            DataAPI pricenow2 = await response2.Content.ReadAsAsync<DataAPI>();
                            doubles2[0] = Convert.ToDouble(pricenow2.data.last);

                        }
                    }
                    DateTime time2 = DateTime.Now;
                    double pricenow3 = doubles2[0];
                    Console.WriteLine();
                    Console.WriteLine("Price now:" + pricenow3 + "******now:" + time2);
                    Console.WriteLine();
                    Console.WriteLine("Percentage change in price:%" + calculation.PriceCalculation4(pricenow3, price));


                    string outputaddress = $@"C:\Users\ASUS\Desktop\New folder\Will price.csv";
                    StreamWriter writer = new StreamWriter(outputaddress);
                    writer.Write("The price of the next few hours(May be the maximum price of the day): " +
                        price + "\n Price now:" + pricenow3 +
                       "\n Percentage change in price:%" + calculation.PriceCalculation4(pricenow3, price));
                    writer.Close();

                } while (true);

                break;
            default:
                Console.WriteLine();
                Console.WriteLine("Please enter number 0 or number 1");
                break;
        }
    }
    else
    {
        Console.WriteLine("Error");
    }
    Console.WriteLine();
    Console.WriteLine("Do you want to continue? (y or n)");
    do
    {
        output = Console.ReadKey(true).KeyChar.ToString();
    }
    while (output.ToUpper() != "Y" && output.ToUpper() != "N");

} while (output.ToUpper() == "Y");
Console.WriteLine();
End();
void End()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Thank you for using this program");
    Console.ResetColor();
}