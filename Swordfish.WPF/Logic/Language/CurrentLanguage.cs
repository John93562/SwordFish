using Swordfish.WPF.Logic;
using System.Collections.Generic;
using System.ComponentModel;

namespace Swordfish.Logic
{
    public class CurrentLanguage : INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }


        private bool isUsLanguage;
        public bool IsUsLanguage
        {
            get
            {
                return isUsLanguage;
            }
            set
            {
                isUsLanguage = value;
                OnPropertyChanged(nameof(IsUsLanguage));
                OnPropertyChanged(nameof(IsNotUsLanguage));
            }
        }

        public bool IsNotUsLanguage => !IsUsLanguage;
        private bool isGreekLanguage;
        public bool IsGreekLanguage
        {
            get
            {
                return isGreekLanguage;
            }
            set
            {
                isGreekLanguage = value;
                OnPropertyChanged(nameof(IsGreekLanguage));
                OnPropertyChanged(nameof(IsNotGreekLanguage));
            }
        }
        public bool IsNotGreekLanguage => !IsGreekLanguage; 

        public Dictionary<string, string> CurrentLanguageDictionary { get; set; }


        public CurrentLanguage(Language inputLanguage)
        {

            ReRenderLanguage(inputLanguage);

        }

        public void ReRenderLanguage(Language inputLanguage)
        {
            CurrentLanguageDictionary = LanguageSupport.ChangeLanguage(inputLanguage);

            switch (inputLanguage)
            {
                case Language.GR:
                    IsGreekLanguage = true;
                    IsUsLanguage = false;
                    break;
                case Language.US:
                    IsGreekLanguage = false;
                    IsUsLanguage = true;
                    break;
                default:
                    IsGreekLanguage = false;
                    IsUsLanguage = true;
                    break;
            }


            ChangeTextOfLanguage();
        }


        void ChangeTextOfLanguage()
        {
            string temp;
            if (CurrentLanguageDictionary.TryGetValue(nameof(DecryptFile), out temp))
                DecryptFile = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(DecryptButton), out temp))
                DecryptButton = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(EncryptFile), out temp))
                EncryptFile = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(EncryptButton), out temp))
                EncryptButton = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(EncryptFolder), out temp))
                EncryptFolder = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(DecryptionSuccess), out temp))
                DecryptionSuccess = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(DecryptionFail), out temp))
                DecryptionFail = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(EncryptionSuccess), out temp))
                EncryptionSuccess = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(EncryptionFail), out temp))
                EncryptionFail = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(TypeThe2Passwords), out temp))
                TypeThe2Passwords = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(PasswordsDoNotMatch), out temp))
                PasswordsDoNotMatch = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(PasswordsDoNotMatchContinue), out temp))
                PasswordsDoNotMatchContinue = temp;

            if (CurrentLanguageDictionary.TryGetValue("1stPassword", out temp))
                FirstPassword = temp;

            if (CurrentLanguageDictionary.TryGetValue("2ndPassword", out temp))
                SecondPassword = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(ValidateButton), out temp))
                ValidateButton = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(YouWillNeed), out temp))
                YouWillNeed = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(AvailableForDecryption), out temp))
                AvailableForDecryption = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(AvailableForEncryption), out temp))
                AvailableForEncryption = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(Info), out temp))
                Info = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(ProgramMaker), out temp))
                ProgramMaker = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(OpenSource), out temp))
                OpenSource = temp;

            if (CurrentLanguageDictionary.TryGetValue(nameof(SendMeAnEmail), out temp))
                SendMeAnEmail = temp;







        }

        private string sendMeAnEmail;
        public string SendMeAnEmail
        {
            get
            {
                return sendMeAnEmail;
            }
            set
            {
                sendMeAnEmail = value;
                OnPropertyChanged(nameof(SendMeAnEmail));
            }
        }



        private string openSource;
        public string OpenSource
        {
            get
            {
                return openSource;
            }
            set
            {
                openSource = value;
                OnPropertyChanged(nameof(OpenSource));
            }
        }


        private string programMaker;
        public string ProgramMaker
        {
            get
            {
                return programMaker;
            }
            set
            {
                programMaker = value;
                OnPropertyChanged(nameof(ProgramMaker));
            }
        }
        private string info;
        public string Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                OnPropertyChanged(nameof(Info));
            }
        }

        private string availableForEncryption;
        public string AvailableForEncryption
        {
            get
            {
                return availableForEncryption;
            }
            set
            {
                availableForEncryption = value;
                OnPropertyChanged(nameof(AvailableForEncryption));
            }
        }

        private string availableForDecryption;
        public string AvailableForDecryption
        {
            get
            {
                return availableForDecryption;
            }
            set
            {
                availableForDecryption = value;
                OnPropertyChanged(nameof(AvailableForDecryption));
            }
        }


        private string youWillNeed;
        public string YouWillNeed
        {
            get
            {
                return youWillNeed;
            }
            set
            {
                youWillNeed = value;
                OnPropertyChanged(nameof(YouWillNeed));
            }
        }


        private string validateButton;
        public string ValidateButton
        {
            get
            {
                return validateButton;
            }
            set
            {
                validateButton = value;
                OnPropertyChanged(nameof(ValidateButton));
            }
        }
        private string secondPassword;
        public string SecondPassword
        {
            get
            {
                return secondPassword;
            }
            set
            {
                secondPassword = value;
                OnPropertyChanged(nameof(SecondPassword));
            }
        }

        private string firstPassword;
        public string FirstPassword
        {
            get
            {
                return firstPassword;
            }
            set
            {
                firstPassword = value;
                OnPropertyChanged(nameof(FirstPassword));
            }
        }

        private string passwordsDoNotMatchContinue;
        public string PasswordsDoNotMatchContinue
        {
            get
            {
                return passwordsDoNotMatchContinue;
            }
            set
            {
                passwordsDoNotMatchContinue = value;
                OnPropertyChanged(nameof(PasswordsDoNotMatchContinue));
            }
        }

        private string passwordsDoNotMatch;
        public string PasswordsDoNotMatch
        {
            get
            {
                return passwordsDoNotMatch;
            }
            set
            {
                passwordsDoNotMatch = value;
                OnPropertyChanged(nameof(PasswordsDoNotMatch));
            }
        }

        private string typeThe2Passwords;
        public string TypeThe2Passwords
        {
            get
            {
                return typeThe2Passwords;
            }
            set
            {
                typeThe2Passwords = value;
                OnPropertyChanged(nameof(TypeThe2Passwords));
            }
        }
        private string encryptionFail;
        public string EncryptionFail
        {
            get
            {
                return encryptionFail;
            }
            set
            {
                encryptionFail = value;
                OnPropertyChanged(nameof(EncryptionFail));
            }
        }

        private string encryptionSuccess;
        public string EncryptionSuccess
        {
            get
            {
                return encryptionSuccess;
            }
            set
            {
                encryptionSuccess = value;
                OnPropertyChanged(nameof(EncryptionSuccess));
            }
        }

        private string decryptionFail;
        public string DecryptionFail
        {
            get
            {
                return decryptionFail; 
            }
            set
            {
                decryptionFail = value;
                OnPropertyChanged(nameof(DecryptionFail));
            }
        }

        private string decryptionSuccess;
        public string DecryptionSuccess
        {
            get
            {
                return decryptionSuccess;
            }
            set
            {
                decryptionSuccess = value;
                OnPropertyChanged(nameof(DecryptionSuccess));
            }
        }
        private string encryptFolder;
        public string EncryptFolder
        {
            get
            {
                return encryptFolder;
            }
            set
            {
                encryptFolder = value;
                OnPropertyChanged(nameof(EncryptFolder));
            }
        }
        private string encryptButton;
        public string EncryptButton
        {
            get
            {
                return encryptButton;
            }
            set
            {
                encryptButton = value;
                OnPropertyChanged(nameof(EncryptButton));
            }
        }
        private string encryptFile;
        public string EncryptFile
        {
            get
            {
                return encryptFile;
            }
            set
            {
                encryptFile = value;
                OnPropertyChanged(nameof(EncryptFile));
            }
        }
        private string decryptButton;
        public string DecryptButton
        {
            get
            {
                return decryptButton;
            }
            set
            {
                decryptButton = value;
                OnPropertyChanged(nameof(DecryptButton));
            }
        }


        private string decryptFile;
        public string DecryptFile
        {
            get
            {
                return decryptFile;
            }
            set
            {
                decryptFile = value;
                OnPropertyChanged(nameof(DecryptFile));
            }
        }


    }
}
