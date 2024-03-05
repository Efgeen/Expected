global using _EXPECTED_H;
global using static _EXPECTED_H.SExpected;
namespace _EXPECTED_H;
public struct SExpected {
	private readonly bool m_hasValue;
	private readonly static SExpected s_expected;
	private readonly static SExpected s_unexpected;
	public readonly bool HasValue => m_hasValue;
	public static SExpected Expected => s_expected;
	public SExpected() => this = s_expected;
	private SExpected(bool hasValue) => m_hasValue = hasValue;
	static SExpected() => (s_expected, s_unexpected) = (new(true), new(false));
	public static implicit operator bool(SExpected expected) => expected.m_hasValue;
	public static implicit operator SExpected(bool hasValue) => hasValue ? s_expected : s_unexpected;
	public static bool operator !(SExpected expected) => expected ? s_unexpected : s_expected;
}
public struct SExpected<E> {
	private readonly bool m_hasValue;
	private readonly E m_error;
	private static readonly SExpected<E> s_expected;
	private static readonly SExpected<E> s_unexpected;
	public readonly bool HasValue => m_hasValue;
	public readonly E Error => m_error;
	public SExpected() => this = s_expected;
	private SExpected(bool hasValue, object? error = null) => (m_hasValue, m_error) = (hasValue, error != null ? (E)error : default!);
	public SExpected(E error) => this = error != null ? new(false, error) : s_expected;
	static SExpected() => (s_expected, s_unexpected) = (new(true), new(false));
	public static implicit operator bool(SExpected<E> expected) => expected.m_hasValue;
	public static implicit operator E(SExpected<E> expected) => expected.m_error;
	public static implicit operator SExpected<E>(E error) => new(error);
	public static implicit operator SExpected(SExpected<E> expected) => (SExpected)expected;
	public static implicit operator SExpected<E>(SExpected expected) => expected ? s_expected : s_unexpected;
}
public struct SExpected<T, E> {
	private readonly bool m_hasValue;
	private readonly T m_value;
	private readonly E m_error;
	private readonly int m_length;
	private static readonly SExpected<T, E> s_expected;
	private static readonly SExpected<T, E> s_unexpected;
	public readonly bool HasValue => m_hasValue;
	public readonly T Value => m_value;
	public readonly E Error => m_error;
	public readonly int Length => m_length;
	public readonly object this[int index] {
		get => m_length < 0x00 ? m_value! : ((Array)(object)m_value!).GetValue(index)!;
		set {
			if (m_length < 0x00) {
				return;
			}
			((Array)(object)m_value!).SetValue(value, index);
		}
	}
	public SExpected() => this = s_expected;
	private SExpected(bool hasValue, object? error = null) {
		if (m_hasValue = hasValue) {
			if (error != null) {
				m_value = (T)error;
				m_length = typeof(T).IsArray ? ((Array)error).Length : -0x01;
			}
			else {
				m_value = default!;
				m_length = -0x01;
			}
			m_error = default!;
		}
		else {
			m_value = default!;
			m_error = error != null ? (E)error : default!;
			m_length = -0x01;
		}
	}
	public SExpected(T value) => this = value != null ? new(true, value) : s_expected;
	public SExpected(E error) => this = error != null ? new(false, error) : s_unexpected;
	static SExpected() => (s_expected, s_unexpected) = (new(true), new(false));
	public static implicit operator bool(SExpected<T, E> expected) => expected.m_hasValue;
	public static implicit operator T(SExpected<T, E> expected) => expected.m_value;
	public static implicit operator E(SExpected<T, E> expected) => expected.m_error;
	public static implicit operator SExpected<T, E>(T value) => new(value);
	public static implicit operator SExpected<T, E>(E error) => new(error);
	public static implicit operator SExpected(SExpected<T, E> expected) => (SExpected)expected;
	public static implicit operator SExpected<T, E>(SExpected expected) => expected ? s_expected : s_unexpected;
	public static implicit operator SExpected<E>(SExpected<T, E> expected) => (SExpected<E>)expected;
	public static implicit operator SExpected<T, E>(SExpected<E> expected) => expected ? s_expected : s_unexpected;
}
