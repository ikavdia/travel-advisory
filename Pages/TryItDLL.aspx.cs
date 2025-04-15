using System;
using DLLComponent;

namespace Pages
{
    public partial class TryItDLL : System.Web.UI.Page
    {
        protected void btnHash_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string hashedValue = EncryptionUtility.ComputeHash(input);
            lblResult.Text = $"Hashed Value: {hashedValue}";
        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string encryptedValue = EncryptionUtility.Encrypt(input);
            lblResult.Text = $"Encrypted Value: {encryptedValue}";
        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            string encryptedInput = txtInput.Text;
            try
            {
                string decryptedValue = EncryptionUtility.Decrypt(encryptedInput);
                lblResult.Text = $"Decrypted Value: {decryptedValue}";
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Error during decryption: {ex.Message}";
            }
        }
    }
}