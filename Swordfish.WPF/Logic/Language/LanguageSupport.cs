using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swordfish.WPF.Logic
{
    public enum Language
    {
        GR,
        US
    }

    public static class LanguageSupport
    {
        static LanguageSupport()
        {
            GreekVocabulary = new Dictionary<string, string>()
            {
                { "DecryptFile" ,"Αποκρυπτογράφησε Αρχείο" },
                { "DecryptButton" ,"Αποκρυπτογράφηση" },
                { "EncryptFile" ,"Κρυπτογράφησε Αρχείο" },
                { "EncryptButton" ,"Κρυπτογράφηση" },
                { "EncryptFolder" ,"Κρυπτογράφησε Φάκελο" },
                { "DecryptionSuccess" ,"Η Αποκρυπτογράφηση έγινε με επιτυχία στο Path:" },
                { "DecryptionFail" ,"Η Αποκρυπτογράφηση απέτυχε." },
                { "EncryptionSuccess" ,"Η Κρυπτογράφηση έγινε με επιτυχία στο Path:" },
                { "EncryptionFail" ,"Η Κρυπτογράφηση απέτυχε." },
                { "TypeThe2Passwords" ,"Πληκτολόγησε τους 2 Κωδικούς" },
                { "PasswordsDoNotMatch" ,"Οι κωδικοί δεν είναι σωστοί. Έχεις " },
                { "PasswordsDoNotMatchContinue" ," ακόμα προσπάθειες." },
                { "1stPassword" ,"1ος Κωδικός" },
                { "2ndPassword" ,"2ος Κωδικός" },
                { "ValidateButton" ,"Επαλήθευση" },
                { "YouWillNeed" ,"Θα χρειαστείς" },
                { "AvailableForDecryption" ,"Διαθέσιμα για την αποκρυπτογράφηση." },
                { "AvailableForEncryption" ,"Διαθέσιμα για την Κρυπτογράφηση." },
                { "Info" ,"Πληροφορίες" },
                { "ProgramMaker" ,"Το πρόγραμμα φτιάχτηκε από τον" },
                { "OpenSource" ,"Το SwordFish είναι Open Source στο Github" },
                { "SendMeAnEmail" ,"Στείλτε μου Email" },
            };
            EnglishVocabulary = new Dictionary<string, string>()
            {
                { "DecryptFile" ,"Decrypt File" },
                { "DecryptButton" ,"Decrypt" },
                { "EncryptFile" ,"Encrypt File" },
                { "EncryptButton" ,"Encrypt" },
                { "EncryptFolder" ,"Encrypt Folder" },
                { "DecryptionSuccess" ,"Decryption was Successful on Path:" },
                { "DecryptionFail" ,"Decryption Failed." },
                { "EncryptionSuccess" ,"Encryption was Successful on Path:" },
                { "EncryptionFail" ,"Encryption Failed." },
                { "TypeThe2Passwords" ,"Type in the 2 Passwords given" },
                { "PasswordsDoNotMatch" ,"Passwords do not match. You have got " },
                { "PasswordsDoNotMatchContinue" ," Tries left" },
                { "1stPassword" ,"1st Password" },
                { "2ndPassword" ,"2nd Password" },
                { "ValidateButton" ,"Validate" },
                { "YouWillNeed" ,"You Will Need" },
                { "AvailableForDecryption" ,"Available for Decryption." },
                { "AvailableForEncryption" ,"Available for Encryption." },
                { "Info" ,"Info" },
                { "ProgramMaker" ,"The program is made by" },
                { "OpenSource" ,"SwordFish is Open Source on Github" },
                { "SendMeAnEmail" ,"Email me at" },
            };
        }


        public static Dictionary<string, string> EnglishVocabulary { get; set; } = new Dictionary<string, string>();
        public static Dictionary<string, string> GreekVocabulary { get; set; } = new Dictionary<string, string>();


        public static Dictionary<string, string> ChangeLanguage(Language language)
        {

            var languageReturned = language switch
            {
                Language.GR => GreekVocabulary,
                Language.US => EnglishVocabulary,
                _ => EnglishVocabulary
            };




            return languageReturned;
        }






    }
}
