using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3_IsabelaAmorim
{
    internal class IntroOutro
    {
      internal void Welcome() //Self-explanatory, I just made a different class so it wouldn't get in the way of the rest of the coding
        {
            Console.WriteLine(" Welcome to the Die Game!");
        }
        internal void Goodbye()
        {
            string[] bananaCat = new string[35];
            bananaCat[0] = "  ";
            bananaCat[1] = "                                             .@@@@+                                                              ";
            bananaCat[2] = "                                              @@@@@                                                              ";
            bananaCat[3] = "                                              *@@@@#                                                           ";
            bananaCat[4] = "                                               %@@@@                                                          ";
            bananaCat[5] = "                                                @@@@+                                                     ";
            bananaCat[6] = "                                               -@@#-::::.                                                ";
            bananaCat[7] = "                                              -+%#.........                                               ";
            bananaCat[8] = "                                             .::=-.........:+                                                   ";
            bananaCat[9] = "                                             =:.:............==                                            ";
            bananaCat[10] = "    _______________________________         .=-:..............-=                                              ";
            bananaCat[11] = "   |    Thank you for playing!     |        -=-:..............-=+                                         ";
            bananaCat[12] = "    -------------------------------         *===++++=+=-:......=*                                            ";
            bananaCat[13] = "                                           :*+==+==-==+++++-....=-                                            ";
            bananaCat[14] = "                                            ++++++=-=**++++=-...=-                                             ";
            bananaCat[15] = "                                           -======-:--=======-:..=                                             ";
            bananaCat[16] = "                                           --:.-:..  .-::-=++==..-                                            ";
            bananaCat[17] = "                                           =@@#.:    ..%@@%==+=..:                                              ";
            bananaCat[18] = "                                           :+#**=.  .-+@@%=:==...:.                                              ";
            bananaCat[19] = "                                            --.:::-:-:   :==-....:+                                         ";
            bananaCat[20] = "                                             -=--*++= ..=*:.......-                                            ";
            bananaCat[21] = "                                              -=*#%#**+-.........:.                                             ";
            bananaCat[22] = "                                               +=-=*=:...........-                                              ";
            bananaCat[23] = "                                               +=-::............:+                                              ";
            bananaCat[24] = "                                               +-:.:........-:..:=                                              ";
            bananaCat[25] = "                                               +-::-........*-....                                              ";
            bananaCat[26] = "                                             =+*-:.........--...----=                                           ";
            bananaCat[27] = "                                           -:#*#-+:.......=-..:*+::::-+                                         ";
            bananaCat[28] = "                                          %@* .#=#%=....::...-***.==--+                                        ";
            bananaCat[29] = "                                               %#@@#=-.....:+*#*    #*                                          ";
            bananaCat[30] = "                                                @@@@@%=..::=#@                                                   ";
            bananaCat[31] = "                                                %@@@@*--==:.-                                                   ";
            bananaCat[32] = "                                               +++#%@@@@@-:::-                                                  ";
            bananaCat[33] = "                                               *++**     #-::-.                                               ";
            bananaCat[34] = "                                              +#++*#     .=-::+. ";

            for (int i = 0; i < bananaCat.Length; i++)
            {
                Console.WriteLine(bananaCat[i]);
            }
        }
    }
}
