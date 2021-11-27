using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Шахматы.Properties;

namespace Шахматы
{
    /// <summary>
    /// Так как есть несколько стилей фигур-изображений, то 
    /// необходим регулятор, который укажет необходимый набор.
    /// </summary>
    class clImagePakFigures
    {
        #region Firures
        private readonly Dictionary<string, Image> FigPakDeff = new Dictionary<string, Image>
                                            {
                                                {"бел_конь", Resources.белый_конь},
                                                {"бел_кароль", Resources.белый_король},
                                                {"бел_ладья", Resources.белый_ладья},
                                                {"бел_пешка", Resources.белый_пешка},
                                                {"бел_слон", Resources.белый_слон},
                                                {"бел_ферзь", Resources.белый_ферзь},
                                                {"чер_конь", Resources.черный_конь},
                                                {"чер_кароль", Resources.черный_король},
                                                {"чер_ладья", Resources.черный_ладья},
                                                {"чер_пешка", Resources.черный_пешка},
                                                {"чер_слон", Resources.черный_слон},
                                                {"чер_ферзь", Resources.черный_ферзь}
                                            };

        private readonly Dictionary<string, Image> FigPakClassik = new Dictionary<string, Image>
                                           {
                                               {"бел_конь1", Resources.белый_конь1},
                                               {"бел_кароль1", Resources.белый_король1},
                                               {"бел_ладья1", Resources.белый_ладья1},
                                               {"бел_пешка1", Resources.белый_пешка1},
                                               {"бел_слон1", Resources.белый_слон1},
                                               {"бел_ферзь1", Resources.белый_ферзь1},
                                               {"чер_конь1", Resources.черный_конь1},
                                               {"чер_кароль1", Resources.черный_король1},
                                               {"чер_ладья1", Resources.черный_ладья1},
                                               {"чер_пешка1", Resources.черный_пешка1},
                                               {"чер_слон1", Resources.черный_слон1},
                                               {"чер_ферзь1", Resources.черный_ферзь1}
                                           };

        private readonly Dictionary<string, Image> FigPakAutor = new Dictionary<string, Image>
                                             {
                                                 {"бел_конь2", Resources.белый_конь2},
                                                 {"бел_кароль2", Resources.белый_король2},
                                                 {"бел_ладья2", Resources.белый_ладья2},
                                                 {"бел_пешка2", Resources.белый_пешка2},
                                                 {"бел_слон2", Resources.белый_слон2},
                                                 {"бел_ферзь2", Resources.белый_ферзь2},
                                                 {"чер_конь2", Resources.черный_конь2},
                                                 {"чер_кароль2", Resources.черный_король2},
                                                 {"чер_ладья2", Resources.черный_ладья2},
                                                 {"чер_пешка2", Resources.черный_пешка2},
                                                 {"чер_слон2", Resources.черный_слон2},
                                                 {"чер_ферзь2", Resources.черный_ферзь2}
                                             };

        private readonly Dictionary<string, string> FigAssociative = new Dictionary<string, string>
                                             {
                                                 {"btnIKoni", "конь" },
                                                 {"btnILaden", "ладья" },
                                                 {"btnISlon", "слон" },
                                                 {"btnIFerz", "ферзь" }
                                             };

        #endregion

        public clImagePakFigures(int typePak)
        {
            CountFigArrPak = FigPakDeff.Count;
            switch (typePak)
            {
                case 0: ImgPak = new Dictionary<string, Image>(FigPakDeff);
                    break;
                case 1: ImgPak = new Dictionary<string, Image>(FigPakAutor);
                    break;
                case 2: ImgPak = new Dictionary<string, Image>(FigPakClassik);
                    break;
            }
        }

        /// <summary>
        /// На вход тег типо "btnIFerz" на выходе "ферзь"
        /// </summary>
        internal string TransformToAssociativFig(string associative)
        {
            return (from variable in FigAssociative where variable.Key == associative select variable.Value).FirstOrDefault();
        }

        internal int CountFigArrPak { get; private set; }

        internal readonly Dictionary<string, Image> ImgPak;
    }
}
