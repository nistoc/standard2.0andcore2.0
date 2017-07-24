// ReSharper disable CheckNamespace

namespace Hub.FacebookMessenger.Send
{
    /// <summary>
    /// ������ �������� ���������� ������
    /// </summary>
    public abstract class FacebookMessageContentQuickReplyBase
    {
        protected FacebookMessageContentQuickReplyBase(string contentType)
        {
            content_type = contentType;
        }

        /// <summary>
        /// *text* ��� *location*
        /// </summary>
        public string content_type { get; }

        /// <summary>
        /// URL ����������� ��� ������� ������� text
        /// - �� �����������.
        /// - ����������� ������ ���� �������� �� ����� 24 x 24. ��� ����� �����������, � ��� ������ ����� �������
        /// </summary>
        public string image_url { get; set; }
    }
}