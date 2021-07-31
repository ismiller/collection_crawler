using System;
using IsMiller.CollectionCrawler.Abstractions;

namespace IsMiller.CollectionCrawler.Models
{
    /// <summary>
    /// Представляет контейнер для контейнеров содержащих элементы коллекции обхода.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции для обхода.</typeparam>
    public sealed class NodeContainer<T> : INodesContainer<T>
    {
        #region Public Properties

        /// <summary>
        /// Предоставляет контейнер элемента коллекции по текущей позиции.
        /// </summary>
        public INode<T> Current { get; }

        /// <summary>
        /// Предоставляет контейнер элемента коллекции следующий за элементом по текущей позиции.
        /// </summary>
        public INode<T> Next { get; }

        /// <summary>
        /// Предоставляет контейнер элемента коллекции предшествующий элементу по текущей позиции.
        /// </summary>
        public INode<T> Previous { get; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Открытый конструктор с параметрами.
        /// </summary>
        /// <param name="current">Предыдущий элемент коллекции.</param>
        /// <param name="previous">Текущий элемент коллекции.</param>
        /// <param name="next">Следующий элемент коллекции.</param>
        public NodeContainer(T current, T previous = default, T next = default)
        {
            Current = current is not null
                ? new Node<T>(current)
                : throw new ArgumentNullException(nameof(current), "Value current is null.");

            Previous = previous is null
                ? new NodeEmpty<T>()
                : new Node<T>(previous);

            Next = next is null
                ? new NodeEmpty<T>()
                : new Node<T>(next);
        }

        #endregion Public Constructors
    }
}