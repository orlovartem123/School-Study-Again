using DocumentFormat.OpenXml.Wordprocessing;

namespace SchoolBusinessLogic.HelperModels.Word
{
    public class WordParagraphProperties
    {
        public string Size { get; set; }
        public bool Bold { get; set; }
        public JustificationValues JustificationValues { get; set; }
    }
}
