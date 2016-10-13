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

		public string	text;				/* null-terminated copy of line text（nullで終わる行のtext）*/
		public ulong	hash;				/* hashcode for line（行のハッシュ値）*/
		public Line		link;				/* handle for linked line（リンクされた行のハンドル　次の行ではなさそう？）*/
		public uint		linenr;				/* line number (any arbitrary value)（行の番号） */
        
		/// <summary>
        /// テキスト１行を保持する。class
        /// </summary>
        /// <param name="textParam">stringテキスト</param>
        /// <param name="linenrParam">行の番号</param>
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
        /// textがスペースかどうかチェックする。
        /// </summary>
        /// <returns></returns>
        public bool IsBlank()
		{
			return /* ( this!=NULL ) && */ utils_isblank(text);
		}
        
		/// <summary>
        /// line.textとthis.line.textが同じなら、 互いのlinkに互いを設定する。
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isIgnoreBlanks">スペースを無視する？</param>
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
        /// line.textとthis.textを比較し同じならtrueを返す。
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
			string s1 = text;                   //比較元テキスト
			string s2 = line.text;              //行のテキスト
			if( isIgnoreBlanks ){
				s1 = remove_blank(s1);
				s2 = remove_blank(s2);
			}
			return ( s1 == s2 );
		}

        // --------------------- helper functions. ---------------------------------
        /// <summary>
        /// 文字列からハッシュ値を返す。
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
        /// 文字列がスペース、タブ、改行かどうかチェックする。
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true:ホワイトスペース</returns>
        protected bool utils_isblank(string str)
		{
			/* having skipped all the blanks, do we see the end delimiter? */
			char[] trimChars = { ' ','\t' };
			str = str.TrimStart( trimChars );
			return ( str.Length == 0 || str[0] == '\r' || str[0] == '\n' );
		}

        
		/// <summary>
        /// スペース、タブを削除する。
        /// </summary>
        /// <param name="str">入力する文字</param>
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
