using System;

namespace csdiff
{
	/// <summary>
	/// Line(s1)
    /// Line.compare(l1)
	/// </summary>
	public class Line : ListItem
	{
		public ulong flags;
		const ulong LF_HASHVALID = 2;

		public string	text;				/* null-terminated copy of line text�inull�ŏI���s��text�j*/
		public ulong	hash;				/* hashcode for line�i�s�̃n�b�V���l�j*/
		public Line		link;				/* handle for linked line�i�����N���ꂽ�s�̃n���h���@���̍s�ł͂Ȃ������H�j*/
		public uint		linenr;				/* line number (any arbitrary value)�i�s�̔ԍ��j */
        
		/// <summary>
        /// �e�L�X�g�P�s��ێ�����Bclass
        /// </summary>
        /// <param name="textParam">string�e�L�X�g</param>
        /// <param name="linenrParam">�s�̔ԍ�</param>
        public Line(string textParam,uint linenrParam)
		{
			text   = textParam;
			link   = null;
			linenr = linenrParam;
			flags  = 0;
			hash   = 0;
		}
        
		/// <summary>
        /// 
        /// </summary>
        /// <param name="isIgnoreBlanks"></param>
        /// <returns></returns>
        public ulong GetHashcode(bool isIgnoreBlanks)
		{
			if( ( flags & LF_HASHVALID ) == 0 ){
				/* hashcode needs to be recalced */
				hash = hash_string( text, isIgnoreBlanks );
				flags |= LF_HASHVALID;
			}
			return hash;
		}

		/// <summary>
        /// text���X�y�[�X���ǂ����`�F�b�N����B
        /// </summary>
        /// <returns></returns>
        public bool IsBlank()
		{
			return /* ( this!=NULL ) && */ utils_isblank(text);
		}
        
		/// <summary>
        /// line.text��this.line.text�������Ȃ�A �݂���link�Ɍ݂���ݒ肷��B
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isIgnoreBlanks">�X�y�[�X�𖳎�����H</param>
        /// <returns></returns>
        public bool Link(Line line,bool isIgnoreBlanks)
		{
			if ( /*(this == NULL) || */ (line == null) ) return false;
			if ( (link != null) || (line.link != null)) return false;

			if ( compare( line, isIgnoreBlanks ) ) {
				link = line;
				line.link = this;
				return true;
			}
			return false;
		}
        
		/// <summary>
        /// line.text��this.text���r�������Ȃ�true��Ԃ��B
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isIgnoreBlanks"></param>
        /// <returns></returns>
        public bool	compare(Line line,bool isIgnoreBlanks)
		{
			/* check that the hashcodes match */
			if( GetHashcode(isIgnoreBlanks) != line.GetHashcode(isIgnoreBlanks) ) return false;

			/* hashcodes match - are the lines really the same ? */
			/* note that this is coupled to gutils\utils.c in definition of blank */
			string s1 = text;                   //��r���e�L�X�g
			string s2 = line.text;              //�s�̃e�L�X�g
			if( isIgnoreBlanks ){
				s1 = remove_blank(s1);
				s2 = remove_blank(s2);
			}
			return ( s1 == s2 );
		}

        // --------------------- helper functions. ---------------------------------
        /// <summary>
        /// �����񂩂�n�b�V���l��Ԃ��B
        /// </summary>
        /// <param name="str"></param>
        /// <param name="bIgnoreBlanks"></param>
        /// <returns></returns>
        protected ulong hash_string(string str, bool bIgnoreBlanks)
		{
            /*			const ulong LARGENUMBER = 6293815;
                        ulong sum = 0;
                        ulong multiple = LARGENUMBER;
                        ulong index = 1;

                        for( int i=0; i<str.Length; i++ ){

                            if (bIgnoreBlanks) {
            //					while ( (str[i] == ' ') || (str[i] == '\t') ) i++;
                            }

                            sum += multiple * index++ * str[i];
                            multiple *= LARGENUMBER;
                        }
                        return(sum);
                        */
            return (ulong)(str.GetHashCode());
		}


		/// <summary>
        /// �����񂪃X�y�[�X�A�^�u�A���s���ǂ����`�F�b�N����B
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true:�z���C�g�X�y�[�X</returns>
        protected bool utils_isblank(string str)
		{
			/* having skipped all the blanks, do we see the end delimiter? */
			char[] trimChars = { ' ','\t' };
			str = str.TrimStart( trimChars );
			return ( str.Length == 0 || str[0] == '\r' || str[0] == '\n' );
		}

        
		/// <summary>
        /// �X�y�[�X�A�^�u���폜����B
        /// </summary>
        /// <param name="str">���͂��镶��</param>
        /// <returns></returns>
        protected string remove_blank(string str)
		{
			char[] trimChars = {' ','\t'};
			string[] splited = str.Split(trimChars);
			str = string.Empty;
			for( int i=0; i<splited.Length; i++ )
			{
				str += splited[i];
			}
			return str;
		}

	}
}
