using IsMiller.CollectionCrawler.Abstractions;

namespace IsMiller.CollectionCrawler.Models
{
    /// <summary>
    /// Представляет пустой контейнер для элемента коллекции обхода.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции для обхода.</typeparam>
    public sealed class NodeEmpty<T> : INode<T>
    {
        #region Public Properties

        /// <summary>
        /// Предоставляет флаг, указывающий, содержит ли нода значение элемента коллекции.
        /// </summary>
        public bool IsEmpty => true;

        /// <summary>
        /// Предоставляет значенеи по умолчанию для элемента коллекции.
        /// </summary>
        public T Value => default;

        #endregion Public Properties
    }
}