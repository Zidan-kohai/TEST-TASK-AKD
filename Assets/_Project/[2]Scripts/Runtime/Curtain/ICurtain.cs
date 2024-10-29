namespace Runtime.Curtain
{
    public interface ICurtain
    {
        /// <summary>
        /// The value of progress must be between 0 and 1.
        /// </summary>
        /// <param name="progress"></param>
        public void SetProgress(float progress);

        public void Show();
        public void Hide();
    }
}
