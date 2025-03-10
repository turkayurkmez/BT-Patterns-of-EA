using Microsoft.Data.SqlClient;

namespace SingleResponsibility
{

    /*
     * SRP:
     * Bir nesnenin, sadece bir sorumluluğu olmalıdır.
     * 
     * İhlali nasıl anlarız?
     *   - Nesneye "senin sorumluluğun ne" diye sorun:
     *   - Eğer nesneyi değiştirmek için birden fazla neden varsa, SRP ihlal edilmiş olabilir.
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

            ProductBusiness productBusiness = new ProductBusiness();
            string name = textBoxProductName.Text;
            decimal price = Convert.ToDecimal(textBoxPrice.Text);

            int affectedRow = productBusiness.Create(name, price);
            string message = affectedRow > 0 ? "Kayıt eklendi" : "Kayıt eklenemedi";

            MessageBox.Show(message);   


            /*
             * SqlConnection ile bağlantı açıp, SqlCommand ile sorgu çalıştırıyoruz.
             * sqlcommand'a parametre ekle....
             * 
             */
        }
    }
}
