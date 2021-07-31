namespace IsMiller.CollectionCrawler.Abstractions
{
    /// <summary>
    /// Описывает контейнер для элемента коллекции обхода.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции.</typeparam>
    public interface INode<out T>
    {
        #region Public Properties

        /// <summary>
        /// Предоставляет флаг, указывающий, является ли контейнер пустым.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Предоставляет значение текущего элемента коллекции.
        /// </summary>
        T Value { get; }

        #endregion Public Properties
    }
}