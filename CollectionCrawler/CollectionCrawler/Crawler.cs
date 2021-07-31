using System;
using System.Collections.Generic;
using IsMiller.CollectionCrawler.Abstractions;
using IsMiller.CollectionCrawler.Models;
using System.Linq;

namespace IsMiller.CollectionCrawler
{
    /// <summary>
    /// Предоставляет методы для обхода коллекции.
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции.</typeparam>
    public sealed class Crawler<T> : ICollectionCrawler<T>
    {
        #region Private Fields

        private readonly int _endPosition;
        private IReadOnlyList<T> _collection;
        private T _current;
        private int _currentPosition;
        private T _next;
        private T _previous;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Предоставляет размер коллекции для обхода.
        /// </summary>
        public int Count => _collection.Count();

        /// <summary>
        /// Предоставляет индекс текущей позиции.
        /// </summary>
        public int CurrentPosition => _currentPosition;

        /// <summary>
        /// Предоставляет флаг, указывающий находится ли индекс обхода в конце коллекции.
        /// </summary>
        public bool IsAtEndPosition =>
            _currentPosition == _endPosition;

        /// <summary>
        /// Предоставляет флаг, указывающий находится ли индекс обхода в начале коллекции.
        /// </summary>
        public bool IsAtStartPosition =>
            _currentPosition == 0;

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Открытый конструктор с параметрами.
        /// </summary>
        /// <param name="collection">Коллекция для обхода.</param>
        public Crawler(IEnumerable<T> collection)
        {
            _collection = (collection is not null && collection.Any())
                 ? new List<T>(collection)
                 : throw new ArgumentNullException(
                    paramName: nameof(collection),
                    message: "Collection is null or empty");

            _currentPosition = 0;
            _endPosition = Count - 1;

            _previous = default;
            _current = _collection.First();
            _next = _endPosition != 1
                ? _collection.ElementAt(_currentPosition + 1)
                : default;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Выполняет предоставление экземпляра класса <see cref="NodeContainer{T}"/>
        /// содержащего предыдущий, текущий и следующий элемент коллекции по индексу текущей позиции.
        /// </summary>
        /// <returns>экземпляра класса <see cref="NodeContainer{T}"/>.</returns>
        public INodesContainer<T> GetCurrent() =>
            new NodeContainer<T>(_current, _previous, _next);

        /// <summary>
        /// Выполняет попытку продвижения обхода по коллекции на один элемент вперед.
        /// </summary>
        /// <returns><see langword="true"/> - если продвижение выполнено успешно,
        /// иначе <see langword="false"/>.</returns>
        public bool TryMoveForward()
        {
            if (IsAtEndPosition)
            {
                return false;
            }

            int nextPosition = _currentPosition + 1;

            _previous = _collection.ElementAt(_currentPosition);
            _current = _collection.ElementAt(nextPosition);
            _next = (nextPosition != _endPosition)
                ? _collection.ElementAt(nextPosition + 1)
                : default;

            _currentPosition = nextPosition;

            return true;
        }

        /// <summary>
        /// Выполняет попытку продвижения обхода по коллекции на один элемент обратно.
        /// </summary>
        /// <returns><see langword="true"/> - если продвижение выполнено успешно,
        /// иначе <see langword="false"/>.</returns>
        public bool TryMoveBack()
        {
            if (IsAtStartPosition)
            {
                return false;
            }

            int previousPosition = _currentPosition - 1;

            _previous = (previousPosition != 0)
                ? _collection.ElementAt(previousPosition - 1)
                : default;
            _current = _collection.ElementAt(previousPosition);
            _next = _collection.ElementAt(_currentPosition);

            _currentPosition = previousPosition;

            return true;
        }

        /// <summary>
        /// Выполняет попытку перемещения обхода по коллекции на указанную позицию.
        /// </summary>
        /// <returns><see langword="true"/> - если перемещение выполнено успешно,
        /// иначе <see langword="false"/>.</returns>
        public bool TryMoveToPosition(int position)
        {
            if (position < 0 || position > _endPosition)
            {
                _previous = position > 0
                    ? _collection.ElementAt(position - 1)
                    : default;

                _current = _collection.ElementAt(position);

                _next = position < _endPosition
                    ? _collection.ElementAt(position)
                    : default;
            }

            return true;
        }

        #endregion Public Methods
    }
}