﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.CommandLine.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VSUpdatesCleaner.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Невозможно считать &apos;{0}&apos; так как ожидается тип &apos;{1}&apos;..
        /// </summary>
        internal static string ArgumentConversionCannotParse {
            get {
                return ResourceManager.GetString("ArgumentConversionCannotParse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Невозможно считать аргумент &apos;{0}&apos; для команды &apos;{1}&apos; так как ожидается тип &apos;{2}&apos;..
        /// </summary>
        internal static string ArgumentConversionCannotParseForCommand {
            get {
                return ResourceManager.GetString("ArgumentConversionCannotParseForCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Невозможно считать аргумент &apos;{0}&apos; для опции &apos;{1}&apos; так как ожидается тип &apos;{2}&apos;..
        /// </summary>
        internal static string ArgumentConversionCannotParseForOption {
            get {
                return ResourceManager.GetString("ArgumentConversionCannotParseForOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Команда &apos;{0}&apos; требует более, чем {1} арумента(ов), но было введено {2}..
        /// </summary>
        internal static string CommandExpectsFewerArguments {
            get {
                return ResourceManager.GetString("CommandExpectsFewerArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Команда &apos;{0}&apos; требует один аргумент, но было введено {1}..
        /// </summary>
        internal static string CommandExpectsOneArgument {
            get {
                return ResourceManager.GetString("CommandExpectsOneArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Для команды &apos;{0}&apos; не введены аргументы..
        /// </summary>
        internal static string CommandNoArgumentProvided {
            get {
                return ResourceManager.GetString("CommandNoArgumentProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Требуемый аргумент не введен &apos;{0}&apos;..
        /// </summary>
        internal static string CommandRequiredArgumentMissing {
            get {
                return ResourceManager.GetString("CommandRequiredArgumentMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Директория не существует: &apos;{0}&apos;..
        /// </summary>
        internal static string DirectoryDoesNotExist {
            get {
                return ResourceManager.GetString("DirectoryDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ошибка чтения файла ответов &apos;{0}&apos;: {1}.
        /// </summary>
        internal static string ErrorReadingResponseFile {
            get {
                return ResourceManager.GetString("ErrorReadingResponseFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Необработанное исключение: .
        /// </summary>
        internal static string ExceptionHandlerHeader {
            get {
                return ResourceManager.GetString("ExceptionHandlerHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Файл не существует: &apos;{0}&apos;..
        /// </summary>
        internal static string FileDoesNotExist {
            get {
                return ResourceManager.GetString("FileDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Файл или директория не существует: &apos;{0}&apos;..
        /// </summary>
        internal static string FileOrDirectoryDoesNotExist {
            get {
                return ResourceManager.GetString("FileOrDirectoryDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Аргументы переданы запущенному приложению..
        /// </summary>
        internal static string HelpAdditionalArgumentsDescription {
            get {
                return ResourceManager.GetString("HelpAdditionalArgumentsDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Дополнительные аргументы:.
        /// </summary>
        internal static string HelpAdditionalArgumentsTitle {
            get {
                return ResourceManager.GetString("HelpAdditionalArgumentsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на default.
        /// </summary>
        internal static string HelpArgumentDefaultValueLabel {
            get {
                return ResourceManager.GetString("HelpArgumentDefaultValueLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Аргументы:.
        /// </summary>
        internal static string HelpArgumentsTitle {
            get {
                return ResourceManager.GetString("HelpArgumentsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Команды:.
        /// </summary>
        internal static string HelpCommandsTitle {
            get {
                return ResourceManager.GetString("HelpCommandsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Описание:.
        /// </summary>
        internal static string HelpDescriptionTitle {
            get {
                return ResourceManager.GetString("HelpDescriptionTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Показать справку и руководство.
        /// </summary>
        internal static string HelpOptionDescription {
            get {
                return ResourceManager.GetString("HelpOptionDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на (ТРЕБУЕТСЯ).
        /// </summary>
        internal static string HelpOptionsRequiredLabel {
            get {
                return ResourceManager.GetString("HelpOptionsRequiredLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Опции:.
        /// </summary>
        internal static string HelpOptionsTitle {
            get {
                return ResourceManager.GetString("HelpOptionsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на [[--] &lt;дополнительные аргументы&gt;...]].
        /// </summary>
        internal static string HelpUsageAdditionalArguments {
            get {
                return ResourceManager.GetString("HelpUsageAdditionalArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на [команда].
        /// </summary>
        internal static string HelpUsageCommand {
            get {
                return ResourceManager.GetString("HelpUsageCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на [опции].
        /// </summary>
        internal static string HelpUsageOptions {
            get {
                return ResourceManager.GetString("HelpUsageOptions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Применение:.
        /// </summary>
        internal static string HelpUsageTitle {
            get {
                return ResourceManager.GetString("HelpUsageTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Недопустимый символ в имени файла: &apos;{0}&apos;..
        /// </summary>
        internal static string InvalidCharactersInFileName {
            get {
                return ResourceManager.GetString("InvalidCharactersInFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Недопустимый символ в пути: &apos;{0}&apos;..
        /// </summary>
        internal static string InvalidCharactersInPath {
            get {
                return ResourceManager.GetString("InvalidCharactersInPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Опция &apos;{0}&apos; требует более, чем {1} аргумента(ов), но было введено {2}..
        /// </summary>
        internal static string OptionExpectsFewerArguments {
            get {
                return ResourceManager.GetString("OptionExpectsFewerArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Опция &apos;{0}&apos; требует один аргумент, но было введено {1}..
        /// </summary>
        internal static string OptionExpectsOneArgument {
            get {
                return ResourceManager.GetString("OptionExpectsOneArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Не введены аргументы для опции &apos;{0}&apos;..
        /// </summary>
        internal static string OptionNoArgumentProvided {
            get {
                return ResourceManager.GetString("OptionNoArgumentProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отсутствует необходимый аргумент для опции: &apos;{0}&apos;..
        /// </summary>
        internal static string OptionRequiredArgumentMissing {
            get {
                return ResourceManager.GetString("OptionRequiredArgumentMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Требуемая команда не введена..
        /// </summary>
        internal static string RequiredCommandWasNotProvided {
            get {
                return ResourceManager.GetString("RequiredCommandWasNotProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Файл ответов не найден &apos;{0}&apos;..
        /// </summary>
        internal static string ResponseFileNotFound {
            get {
                return ResourceManager.GetString("ResponseFileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &apos;{0}&apos; не совпало. Вы имели в виду одно из следующего?.
        /// </summary>
        internal static string SuggestionsTokenNotMatched {
            get {
                return ResourceManager.GetString("SuggestionsTokenNotMatched", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Аргумент &apos;{0}&apos; не распознан. Должен быть один из: {1}.
        /// </summary>
        internal static string UnrecognizedArgument {
            get {
                return ResourceManager.GetString("UnrecognizedArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Неопознанная команда или аргумент &apos;{0}&apos;..
        /// </summary>
        internal static string UnrecognizedCommandOrArgument {
            get {
                return ResourceManager.GetString("UnrecognizedCommandOrArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {0} опция не может сочетаться с другими аргументами..
        /// </summary>
        internal static string VersionOptionCannotBeCombinedWithOtherArguments {
            get {
                return ResourceManager.GetString("VersionOptionCannotBeCombinedWithOtherArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Показать информацию о версии.
        /// </summary>
        internal static string VersionOptionDescription {
            get {
                return ResourceManager.GetString("VersionOptionDescription", resourceCulture);
            }
        }
    }
}
