using ControlePontos.Dominio.Model.Integracoes;
using ControlePontos.Dominio.Servico;
using ControlePontos.Util.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePontos.Servicos
{
    public class SodexoServico : ISodexoServico
    {
        private const string ServidorSodexo = "https://www.app.sodexo.com.br/PMobileServer/Primeth";
        private readonly byte[] key;

        public SodexoServico()
        {
            this.key = Encoding.UTF8.GetBytes("SOME_KEY33133322");
        }

        public async Task<SodexoHistorioUsoModel> ConsultarSaldoAsync(string numeroCartao, string cpf, CancellationToken cancellationToken)
        {
            using (var http = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "th", "thsaldo" },
                    { "req", this.GerarCodigoRequisicao(numeroCartao, cpf) }
                });

                var response = await http.PostAsync(SodexoServico.ServidorSodexo, content, cancellationToken);
                var json = await response.Content.ReadAsStringAsync();

                var obj = JsonConvert.DeserializeObject(json) as JObject;
                var msg = obj["returnMessage"].ToString();

                if (msg == "OK")
                    return obj.ToObject<SodexoHistorioUsoModel>();
                else
                    throw new Exception(msg);
            }
        }

        private string GerarCodigoRequisicao(string numeroCartao, string cpf)
        {
            var aes = new AesManaged
            {
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var crypt = aes.CreateEncryptor();
            var plain = Encoding.UTF8.GetBytes($"th=thsaldo&cardNumber={numeroCartao}&document={cpf}");
            var cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);

            return cipher.ToHexString();
        }
    }
}