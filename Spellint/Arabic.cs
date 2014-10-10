using System;

namespace Spellint
{
    public class Arabic
    {
        static String[][] literals = new String[2][];

        private static void initLiterals()
        {
            literals[0] = new String[10];
            literals[0][0] = "صفر";
            literals[0][1] = "واحد";
            literals[0][2] = "اثنان";
            literals[0][3] = "ثلاثة";
            literals[0][4] = "أربعة";
            literals[0][5] = "خمسة";
            literals[0][6] = "ستة";
            literals[0][7] = "سبعة";
            literals[0][8] = "ثمانية";
            literals[0][9] = "تسعة";

            literals[1] = new String[9];

            literals[1][0] = "عشرة";
            literals[1][1] = "عشرون";
            literals[1][2] = "ثلاثون";
            literals[1][3] = "أربعون";
            literals[1][4] = "خمسون";
            literals[1][5] = "ستون";
            literals[1][6] = "سبعون";
            literals[1][7] = "ثمانون";
            literals[1][8] = "تسعون";

        }

        public static string Spell(string number)
        {
            return Spell(double.Parse(number));
        }

        public static string Spell(double number)
        {
            initLiterals();
            string result = "";
            uint INTpart = Convert.ToUInt32(Math.Floor(number));
            int FLTpart = (int)Math.Round((number - INTpart) * 100);

            result = SpellInt(INTpart);
            if (FLTpart > 0)
            {
                result = result + " فاصل " + SpellInt((uint)FLTpart);
            }

            return result;

        }
        private static string SpellInt(uint number)
        {
            return SpellBillions(number);
        }

        private static string SpellBillions(uint number)
        {
            uint offset = 1000000000;
            uint billions = number / offset;
            if (billions % offset == 0) { return SpellMillions(number); }
            if (billions % offset == 1 && number % 1000 != 0) { return "مليار" + " و " + SpellMillions(number); }
            if (billions % offset == 2 && number % 1000 != 0) { return "  مليارين" + " و " + SpellMillions(number); }
            if (billions % offset == 1 && number % 1000 == 0) { return " مليار"; }
            if (billions % offset == 2 && number % 1000 == 0) { return "  مليارين"; }
            if (billions % offset > 2 && number % 1000 == 0) { return SpellHundreds(billions) + " ملايير"; }
            if (billions > 2 && billions <= 10) { return SpellHundreds(billions) + " ملايير" + " و " + SpellMillions(number); }
            return SpellHundreds(billions) + " مليار" + " و " + SpellMillions(number);
        }

        private static string SpellMillions(uint number)
        {
            uint offset = 1000000;
            uint millions = number / offset;
            if (millions % offset == 0) { return SpellThousands(number); }
            if (millions % offset == 1 && number % 1000 != 0) { return "مليون" + " و " + SpellThousands(number); }
            if (millions % offset == 2 && number % 1000 != 0) { return "  مليونين" + " و " + SpellThousands(number); }
            if (millions % offset == 1 && number % 1000 == 0) { return " مليون"; }
            if (millions % offset == 2 && number % 1000 == 0) { return "  مليونين"; }
            if (millions % offset > 2 && number % 1000 == 0) { return SpellHundreds(millions) + " ملايين"; }
            if (millions > 2 && millions <= 10) { return SpellHundreds(millions) + " ملايين" + " و " + SpellThousands(number); }
            return SpellHundreds(millions) + " مليون" + " و " + SpellThousands(number);
        }
        private static string SpellThousands(uint number)
        {
            uint offset = 1000;
            uint thaousands = number / offset;
            if (thaousands % offset == 0) { return SpellHundreds(number); }
            if (thaousands % offset == 1 && number % 1000 != 0) { return " الف" + " و " + SpellHundreds(number); }
            if (thaousands % offset == 2 && number % 1000 != 0) { return "  الفان" + " و " + SpellHundreds(number); }
            if (thaousands % offset == 1 && number % 1000 == 0) { return " الف"; }
            if (thaousands % offset == 2 && number % 1000 == 0) { return "  الفان"; }
            if (thaousands % offset > 2 && number % 1000 == 0) { return SpellHundreds(thaousands) + " الاف"; }
            if (thaousands > 2 && thaousands <= 10) { return SpellHundreds(thaousands) + " الاف" + " و " + SpellHundreds(number); }
            return SpellHundreds(thaousands) + " الف" + " و " + SpellHundreds(number);
        }
        private static string SpellHundreds(uint number)
        {
            uint hundreds = number / 100;
            if (hundreds % 10 == 0) { return SpellTens(number); }
            if (hundreds % 10 == 1 && number % 100 != 0) { return " مائة" + " و " + SpellTens(number); }
            if (hundreds % 10 == 2 && number % 100 != 0) { return " مائتان" + " و " + SpellTens(number); }
            if (hundreds % 10 == 1 && number % 100 == 0) { return " مائة"; }
            if (hundreds % 10 == 2 && number % 100 == 0) { return " مائتان"; }
            if (hundreds % 10 > 2 && number % 100 == 0) { return SpellDigit(hundreds) + " مائة"; }
            return SpellDigit(hundreds) + " مائة" + " و " + SpellTens(number);
        }

        private static string SpellTens(uint number)
        {
            if (number % 100 == 10) return " عشرة";
            if (number % 100 == 11) return " احدى عشرة";
            if (number % 100 == 12) return " اثنى عشرة";
            uint tens = number / 10;
            if (number % 10 == 0 && (tens % 10 != 0))
            {
                return literals[1][(tens % 10) - 1];
            }

            if (number % 10 != 0 && (tens % 10 == 0))
            {
                return SpellDigit(number);
            }
            if (number % 10 != 0 && (tens % 10 != 0))
            {
                return SpellDigit(number) + ((tens % 10 != 1) ? " و " : " ") + literals[1][(tens % 10) - 1];
            }
            return SpellDigit(number);
        }

        private static string SpellDigit(uint number)
        {
            return literals[0][number % 10];

        }
    }
}
