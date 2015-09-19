using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class PostProxy
    {
        public Post Post { get; set; }

        public PostProxy(Post i_Post)
        {
            Post = i_Post;
        }

        private string m_DisplayText;
        public string DisplayText
        {
            get
            {
                if (string.IsNullOrEmpty(m_DisplayText))
                {
                    Post.eType? type = Post.Type;
                    string typeString;
                    if (type == null)
                    {
                        typeString = "";
                    }
                    else
                    {
                        typeString = Enum.GetName(typeof(Post.eType), Post.Type);
                    }

                    m_DisplayText = string.Format("[{0}]\t {1}", typeString, Post.Message);
                }

                return m_DisplayText;
            }
        }
    }
}
