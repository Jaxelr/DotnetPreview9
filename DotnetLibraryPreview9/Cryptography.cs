using System.Security.Cryptography;

namespace DotnetLibraryPreview9
{
    public class Cryptography
    {
        void HashAndProcessData(HashAlgorithmName hashAlgorithmName, byte[] data)
        {
            //To avoid having to do this:
            switch (hashAlgorithmName.Name)
            {
                case "SHA256":
                    SHA256.HashData(data);
                    break;
                case "SHA512":
                    SHA512.HashData(data);
                    break;
                //etc......
                default:
                    throw new NotSupportedException();
            }

            //You can use this:
            byte[] hash = CryptographicOperations.HashData(hashAlgorithmName, data);
        }

        //KMAC is implemented in .NET 9 as specified by NIST SP 800-185
        //Only works on windows 11 | linux with openssl 3.0+
        void KmacAlgos()
        {
            byte[] key = [];
            byte[] input = [];
            byte[] mac = Kmac128.HashData(key, input, outputLength: 32);
            byte[] mac256 = Kmac256.HashData(key, input, outputLength: 32);
        }
    }
}
