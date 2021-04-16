using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Ocultacion {
    public class Compresor {
        public static void Comprimir(String origen, String destino) {
            using (var salida = new FileStream(destino, FileMode.Create)) {
                using (var compressionStream = new GZipStream(salida, CompressionMode.Compress)) {
                    using (var lector = new StreamReader(new FileStream(origen, FileMode.Open))) {
                        using (StreamWriter escritor = new StreamWriter(compressionStream)) {
                            escritor.Write(lector.ReadToEnd());
                        }
                    }
                }
            }
        }
        public static string Descomprimir(String resource) {
            System.Reflection.Assembly _assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var entrada = _assembly.GetManifestResourceStream(_assembly.GetName().Name + "." + resource)) {
                using (GZipStream compressionStream = new GZipStream(entrada, CompressionMode.Decompress)) {
                    using (StreamReader lector = new StreamReader(compressionStream)) {
                        return lector.ReadToEnd();
                    }
                }
            }
        }
    }
}
