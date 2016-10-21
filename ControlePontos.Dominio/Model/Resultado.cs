using System;

namespace ControlePontos.Dominio.Model
{
    public enum TipoMensagem
    {
        Sucesso,
        Informacao,
        Aviso,
        Erro
    }

    public class Resultado
    {
        public static Resultado Sucesso(string mensagem = null)
        {
            return new Resultado { Tipo = TipoMensagem.Sucesso, ValorMensagem = mensagem };
        }

        public static Resultado<T> Sucesso<T>(T valor, string mensagem = null)
        {
            return new Resultado<T> { Tipo = TipoMensagem.Sucesso, Valor = valor, ValorMensagem = mensagem };
        }

        public static Resultado Informacao(string mensagem = null)
        {
            return new Resultado { Tipo = TipoMensagem.Informacao, ValorMensagem = mensagem };
        }

        public static Resultado<T> Informacao<T>(T valor, string mensagem = null)
        {
            return new Resultado<T> { Tipo = TipoMensagem.Informacao, Valor = valor, ValorMensagem = mensagem };
        }

        public static Resultado Aviso(string mensagem = null)
        {
            return new Resultado { Tipo = TipoMensagem.Aviso, ValorMensagem = mensagem };
        }

        public static Resultado<T> Aviso<T>(T valor, string mensagem = null)
        {
            return new Resultado<T> { Tipo = TipoMensagem.Aviso, Valor = valor, ValorMensagem = mensagem };
        }

        public static Resultado Erro(Exception excecao = null, string mensagem = null)
        {
            return new Resultado { Tipo = TipoMensagem.Erro, Excecao = excecao, ValorMensagem = mensagem };
        }

        public static Resultado<T> Erro<T>(T valor, Exception excecao = null, string mensagem = null)
        {
            return new Resultado<T> { Tipo = TipoMensagem.Erro, Valor = valor, ValorMensagem = mensagem, Excecao = excecao };
        }

        public TipoMensagem Tipo { get; set; }
        public string ValorMensagem { get; set; }
        public Exception Excecao { get; set; }
    }

    public class Resultado<T> : Resultado
    {
        public static Resultado<T> Sucesso(T valor, string mensagem = null)
        {
            return new Resultado<T> { Tipo = TipoMensagem.Sucesso, Valor = valor, ValorMensagem = mensagem };
        }

        public static Resultado<T> Informacao(T valor, string mensagem = null)
        {
            return new Resultado<T> { Tipo = TipoMensagem.Informacao, Valor = valor, ValorMensagem = mensagem };
        }

        public static Resultado<T> Aviso(T valor, string mensagem = null)
        {
            return new Resultado<T> { Tipo = TipoMensagem.Aviso, Valor = valor, ValorMensagem = mensagem };
        }

        public static Resultado<T> Erro(T valor, Exception excecao = null, string mensagem = null)
        {
            return new Resultado<T> { Tipo = TipoMensagem.Erro, Valor = valor, ValorMensagem = mensagem, Excecao = excecao };
        }

        public T Valor { get; set; }
    }
}