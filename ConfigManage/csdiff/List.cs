using System;

namespace csdiff
{
	/// <summary>
	/// リスト
	/// </summary>
	public class ListItem
	{
		public ListItem m_pNext; //次
		public ListItem m_pPrev; //前

		public ListItem()
		{
			m_pNext = null;
			m_pPrev = null;
		}
		public ListItem GetNext()
		{
			return m_pNext;
		}
		public ListItem GetPrev()
		{
			return m_pPrev;
		}
	}


	/// <summary>
	/// 読み込んだデータのリスト群
	/// </summary>
	public class ListAnchor
	{
		public ListItem m_head;
		public ListItem m_tail;

		public ListAnchor()
		{
			m_head = null;
			m_tail = null;
		}
		public void RemoveAll()
		{
			m_head = null;
			m_tail = null;
		}
		public void AddTail(ListItem item)
		{
			if( m_tail != null ){
				m_tail.m_pNext = item;
				item.m_pPrev = m_tail;
			}
			if( m_head == null ) m_head = item;
			m_tail = item;
		}
		public ListItem GetHead()
		{
			return m_head;
		}
		public ListItem GetTail()
		{
			return m_tail;
		}
		public bool IsEmpty()
		{
			return ( m_tail == null ) && ( m_head == null );
		}
	}
}
