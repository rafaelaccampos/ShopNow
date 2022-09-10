namespace ShopNow
{
    public class Cpf
    {
        public bool Validate(string str)
        {
            if (str != null)
            {
                if (str != "")
                {
                    if (str.Length >= 11 || str.Length <= 14)
                    {

                        str = str
                            .Replace(".", "")
                            .Replace(".", "")
                            .Replace("-", "")
                            .Replace(" ", "");

                        if (!str.All(c => c == str.First()))
                        {
                            try
                            {
                                int d1, d2;
                                int dg1, dg2, rest;
                                int digito;
                                string nDigResult;
                                d1 = d2 = 0;
                                dg1 = dg2 = rest = 0;

                                for (var nCount = 1; nCount < str.Length-1; nCount++)
                                {
                                    // if (isNaN(parseInt(str.substring(nCount -1, nCount)))) {
                                    // 	return false;
                                    // } else {

                                    digito = int.Parse(str.Substring(nCount-1, 1));
                                    d1 = d1 + (11 - nCount) * digito;

                                    d2 = d2 + (12 - nCount) * digito;
                                    // }
                                };

                                rest = (d1 % 11);

                                dg1 = (rest < 2) ? dg1 = 0 : 11 - rest;
                                d2 += 2 * dg1;
                                rest = (d2 % 11);
                                if (rest < 2)
                                    dg2 = 0;
                                else
                                    dg2 = 11 - rest;

                                var nDigVerific = str.Substring(str.Length - 2, 2);
                                nDigResult = "" + dg1 + "" + dg2;
                                return nDigVerific == nDigResult;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Erro !" + e);

                                return false;
                            }
                        }
                        else return false;


                    }
                    else return false;
                }

                return true;
            }
            else return false;
        }
    }
}
