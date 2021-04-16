        static void Main(string[] args) {
            Compresor.Comprimir(@"..\..\consultas.sql", @"..\..\logo.png");
        //    Compresor.Comprimir("99999.sql", "loga.png");
        //    string key = "2ujsLq7QV+l9/oNrE70xhSJ2kgv+v9ek7EbLwiCAoZw=";
        //    string IV = "wpKnuXS2mkOhuKGknRmZSQ==";
        //    Aes aes = Aes.Create();

        //    //byte[] keyAes = Convert.FromBase64String(key);
        //    //byte[] IVAes = Convert.FromBase64String(IV);
        //    //using (MemoryStream msEncrypt = new MemoryStream()) {
        //    //    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, 
        //    //            aes.CreateEncryptor(Convert.FromBase64String(key), 
        //    //            Convert.FromBase64String(IV)), CryptoStreamMode.Write)) {
        //    //        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) {
        //    //            swEncrypt.Write("SELECT ... FROM");
        //    //        }
        //    //        Debug.WriteLine(Convert.ToBase64String(msEncrypt.ToArray()));
        //    //    }
        //    //}
        //    // Program kk;
        //    // kk.GetType().Assembly.
        //    //using (MemoryStream msEncrypt = new MemoryStream(Convert.FromBase64String("oUuKgGzzAXVtb4ET0AGiYg=="))) {
        //    //    using (CryptoStream csDecrypt = new CryptoStream(msEncrypt, aes.CreateDecryptor(Convert.FromBase64String(key),
        //    //            Convert.FromBase64String(IV)), CryptoStreamMode.Read)) {
        //    //        using (StreamReader srDecrypt = new StreamReader(csDecrypt)) {
        //    //            Debug.WriteLine(srDecrypt.ReadToEnd());
        //    //        }
        //    //    }
        //    //}

        //    //using (MemoryStream msEncrypt = new MemoryStream()) {
        //    //    using (GZipStream compressionStream = new GZipStream(msEncrypt, CompressionMode.Compress)) {
        //    //        using (StreamWriter swEncrypt = new StreamWriter(msEncrypt)) {
        //    //            swEncrypt.Write("SELECT ... FROM");
        //    //        }
        //    //        Debug.WriteLine(Convert.ToBase64String(msEncrypt.ToArray()));
        //    //    }
        //    //}
        //    using (MemoryStream msEncrypt = new MemoryStream(Convert.FromBase64String("U0VMRUNUIC4uLiBGUk9N"))) {
        //        using (GZipStream compressionStream = new GZipStream(msEncrypt, CompressionMode.Decompress)) {
        //            using (StreamReader srDecrypt = new StreamReader(msEncrypt)) {
        //                Debug.WriteLine(srDecrypt.ReadToEnd());
        //            }
        //        }
        //    }
        }
    }