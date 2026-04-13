using Cryptlex;
public class LicenseService
{
    public bool ActivateLicense(string productId, string licenseKey, string productData)
    {
        try
        {
            LexActivator.SetProductData(productData);
            LexActivator.SetProductId(productId, LexActivator.PermissionFlags.LA_USER);
            LexActivator.SetLicenseKey(licenseKey);
            int status = LexActivator.ActivateLicense();
            return status == LexStatusCodes.LA_OK ||
                   status == LexStatusCodes.LA_EXPIRED ||
                   status == LexStatusCodes.LA_SUSPENDED;
        }
        catch (LexActivatorException ex)
        {
            // Log error
            return false;
        }
    }
}
