using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;

namespace FlowShop_INFRA
{
    public static class Validacoes
    {
        public static bool StringValidation(string nome)
        {

            if (Regex.IsMatch(nome, @"^[ a-zA-Z záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IntValidation(string cod_compra)
        {
            if (Regex.IsMatch(cod_compra, "[0-9]"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
