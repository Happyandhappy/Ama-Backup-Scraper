using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;
using System.Collections;

namespace Scraper
{
    public partial class Form1 : Form
    {
        DataTable table;
        string url;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitTable()
        {
            table = new DataTable("ScrapDataTable");
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Stars", typeof(string));
            table.Columns.Add("Reviews", typeof(string));
            table.Columns.Add("Price", typeof(string));
            table.Columns.Add("Merchant", typeof(string));
            table.Columns.Add("Bullet", typeof(string));
            table.Columns.Add("Side_image", typeof(string));
            table.Columns.Add("Dimention", typeof(string));
            table.Columns.Add("Item_weight", typeof(string));
            table.Columns.Add("Shipping_weight", typeof(string));
            table.Columns.Add("Manufactuer", typeof(string));
            table.Columns.Add("ASIN", typeof(string));
            table.Columns.Add("Best_seller", typeof(string));

            scrapDataView.DataSource = table;
        }
        private string get_innerText(string xpath, HtmlAgilityPack.HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes(xpath);
            var result = nodes[0].InnerText;
            return result;
;        }

        private string get_innerTexts(string xpath, HtmlAgilityPack.HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes(xpath);
            var result = "";
            for (int i = 0; i < nodes.Count(); i++)
            {
                result = result + "<p>" + adjust_str(nodes[i].InnerText) + "</p>";
            }
            return result;
        }

        private string get_imageUrls(string xpath, HtmlAgilityPack.HtmlDocument doc)
        {
            var result = "";
            var nodes = doc.DocumentNode.SelectNodes(xpath);
            for (int i = 0; i< nodes.Count; i++)
            {
                result = result + "<p>" + nodes[i].GetAttributeValue("src","") + "</p>";
            }
            return result;
        }

        private string adjust_str(string str)
        {
            var trim = str.Trim();
            var nReplace = trim.Replace("\n", "");
            var tReplace = nReplace.Replace("\t", "");
            return tReplace;
        }

        private string content_match(string name, HtmlNodeCollection title_data, HtmlNodeCollection data)
        {
            for (int i = 0; i < title_data.Count; i++){
                if (title_data[i].InnerText.Contains(name))
                    return data[i].InnerText;
            }
            return "";
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            InitTable();
        }

        private async void scrapbutton_Click(object sender, EventArgs e)
        {
            url = scrapUrl.Text;
            //url = "https://www.amazon.com/dp/B01MTB55WH";
            if (url == "")
            {
                MessageBox.Show("Please insert Url!", "Warning!", MessageBoxButtons.OK);
                return;
            }
            HtmlWeb web = new HtmlWeb();
            var doc = await Task.Factory.StartNew(() => web.Load(url));

            var type = adjust_str(get_innerText("//a[@id='bylineInfo']", doc));
            var title = get_innerText("//*[@id='productTitle']", doc);
            var stars = get_innerText("//*[@id='acrPopover']/span[1]/a/i[1]/span", doc);
            var reviews = get_innerText("//*[@id='acrCustomerReviewText']", doc);
            var price = get_innerText("//*[@id='priceblock_ourprice']", doc);
            var merchant = get_innerText("//*[@id='merchant-info']", doc);
            var bullet = get_innerTexts("//*[@id='feature-bullets']/ul/li/span", doc);
            var images = get_imageUrls("//*[@id='altImages']/ul/li/span/span/span/span/span/img", doc);

            var product_content = doc.DocumentNode.SelectNodes("//*[@id='productDetails_detailBullets_sections1']/tr/td");
            var product_title = doc.DocumentNode.SelectNodes("//*[@id='productDetails_detailBullets_sections1']/tr/th");

            var dimention = adjust_str(content_match("Product Dimensions", product_title, product_content));
            var item_weight = adjust_str(content_match("Item Weight", product_title, product_content));
            var shipping_weight = adjust_str(content_match("Shipping Weight", product_title, product_content));
            var manufacturer = adjust_str(content_match("Manufacturer", product_title, product_content));
            var ASIN = adjust_str(content_match("ASIN", product_title, product_content));
            var best_seller_rank = get_innerTexts("//*[@id='productDetails_detailBullets_sections1']/tr/td/span/span", doc);

            table.Rows.Add(type, title, stars, reviews, price, merchant, bullet, images, dimention, item_weight, shipping_weight, manufacturer, ASIN, best_seller_rank);
            StringBuilder csv_content = new StringBuilder();
            if (!File.Exists("output.csv"))
            {
                string[] items = {"Type", "Title", "Stars", "Price", "Merchant", "Bullet",
                                "Side_image", "Dimention", "Item_weight", "Shipping_weight",
                                "Manufactuer", "ASIN", "Best_seller" };
                string newline = "";
                foreach (string item in items)
                {
                    newline = newline + item + ",";
                }
                csv_content.AppendLine(newline);
            }

            ArrayList data = new ArrayList();
            string dataline = ((char)34).ToString() + type + ((char)34).ToString() + "," +
                      ((char)34).ToString() + title.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + stars.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + price.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + merchant.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + bullet.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + images.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + dimention.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + item_weight.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + shipping_weight.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + manufacturer.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + ASIN.Replace("\n", "") + ((char)34).ToString() + "," +
                      ((char)34).ToString() + best_seller_rank.Replace("\n", "") + ((char)34).ToString();

            csv_content.AppendLine(dataline);
            File.AppendAllText("output.csv", csv_content.ToString());
            MessageBox.Show("Scrapping Success!", "Success", MessageBoxButtons.OK);
        }
    }
}
