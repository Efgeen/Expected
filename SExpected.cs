namespace Expected {
	public struct SExpected {
		private readonly bool m_oke;
		private readonly static SExpected s_exp;
		private readonly static SExpected s_une;
		public readonly bool Oke => 
			m_oke;
		public static SExpected Exp => 
			s_exp;
		public SExpected() =>
			this = s_exp;
		private SExpected(bool oke) =>
			m_oke = oke;
		static SExpected() =>
			(s_exp, s_une) = (new(true), new(false));
		public static implicit operator bool(SExpected exp) => 
			exp.m_oke;
		public static implicit operator SExpected(bool oke) => 
			oke ? s_exp : s_une;
		public static bool operator !(SExpected exp) => 
			exp ? s_une : s_exp;
	}
	public struct SExpected<N> {
		private readonly bool m_oke;
		private readonly N m_nay;
		private static readonly SExpected<N> s_exp;
		private static readonly SExpected<N> s_une;
		public readonly bool Oke => 
			m_oke;
		public readonly N Nay => 
			m_nay;
		public SExpected() =>
			this = s_exp;
		private SExpected(bool oke, object? obj = null) =>
			(m_oke, m_nay) = (oke, obj != null ? (N)obj : default!);
		public SExpected(N nay) =>
			this = nay != null ? new(false, nay) : s_exp;
		static SExpected() =>
			(s_exp, s_une) = (new(true), new(false));
		public static implicit operator bool(SExpected<N> exp) => 
			exp.m_oke;
		public static implicit operator N(SExpected<N> exp) => 
			exp.m_nay;
		public static implicit operator SExpected<N>(N nay) => 
			new(nay);
		public static implicit operator SExpected(SExpected<N> exp) => 
			(SExpected)exp;
		public static implicit operator SExpected<N>(SExpected exp) =>
			exp ? s_exp : s_une;
	}
	public struct SExpected<Y, N> {
		private readonly bool m_oke;
		private readonly Y m_yay;
		private readonly N m_nay;
		private readonly int m_len;
		private static readonly SExpected<Y, N> s_exp;
		private static readonly SExpected<Y, N> s_une;
		public readonly bool Oke => 
			m_oke;
		public readonly Y Yay => 
			m_yay;
		public readonly N Nay => 
			m_nay;
		public readonly int Len => 
			m_len;
		public readonly object this[int inx] {
			get =>
				m_len < 0x00 ? m_yay! : ((Array)(object)m_yay!).GetValue(inx)!;
			set {
				if (m_len < 0x00) {
					return;
				}
				((Array)(object)m_yay!).SetValue(value, inx);
			}
		}
		public SExpected() =>
			this = s_exp;
		private SExpected(bool oke, object? obj = null) {
			if (m_oke = oke) {
				if (obj != null) {
					m_yay = (Y)obj;
					m_len = typeof(Y).IsArray ? ((Array)obj).Length : -0x01;
				}
				else {
					m_yay = default!;
					m_len = -0x01;
				}
				m_nay = default!;
			}
			else {
				m_yay = default!;
				m_nay = obj != null ? (N)obj : default!;
				m_len = -0x01;
			}
		}
		public SExpected(Y yay) =>
			this = yay != null ? new(true, yay) : s_exp;
		public SExpected(N nay) => 
			this = nay != null ? new(false, nay) : s_une;
		static SExpected() =>
			(s_exp, s_une) = (new(true), new(false));
		public static implicit operator bool(SExpected<Y, N> exp) => 
			exp.m_oke;
		public static implicit operator Y(SExpected<Y, N> exp) => 
			exp.m_yay;
		public static implicit operator N(SExpected<Y, N> exp) => 
			exp.m_nay;
		public static implicit operator SExpected<Y, N>(Y yay) => 
			new(yay);
		public static implicit operator SExpected<Y, N>(N nay) => 
			new(nay);
		public static implicit operator SExpected(SExpected<Y, N> exp) => 
			(SExpected)exp;
		public static implicit operator SExpected<Y, N>(SExpected exp) =>
			exp ? s_exp : s_une;
		public static implicit operator SExpected<N>(SExpected<Y, N> exp) => 
			(SExpected<N>)exp;
		public static implicit operator SExpected<Y, N>(SExpected<N> exp) =>
			exp ? s_exp : s_une;
	}
}
