using IsMiller.CollectionCrawler.Abstractions;

namespace IsMiller.CollectionCrawler.Models
{
    /// <summary>
    /// Представляет контейнер для элемента коллекции обхода.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции.</typeparam>
    public sealed class Node<T> : INode<T>
    {
        #region Public Properties

        /// <summary>
        /// Предоставляет флаг, указывающий, является ли контейнер пустым.
        /// </summary>
        public bool IsEmpty => false;

        /// <summary>
        /// Предоставляет значение текущего элемента коллекции.
        /// </summary>
        public T Value { get; init; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Открытый конструктор с параметрами.
        /// </summary>
        /// <param name="value">Значение текущего элемента коллекции.</param>
        public Node(T value)
        {
            Value = value;
        }

        #endregion Public Constructors
    }
}