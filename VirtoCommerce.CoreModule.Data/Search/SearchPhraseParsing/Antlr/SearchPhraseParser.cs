//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from SearchPhrase.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace VirtoCommerce.CoreModule.Data.Search.SearchPhraseParsing.Antlr {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class SearchPhraseParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, FD=2, VD=3, RD=4, RangeStart=5, RangeEnd=6, String=7, WS=8;
	public const int
		RULE_searchPhrase = 0, RULE_phrase = 1, RULE_keyword = 2, RULE_filters = 3, 
		RULE_attributeFilter = 4, RULE_rangeFilter = 5, RULE_fieldName = 6, RULE_attributeFilterValue = 7, 
		RULE_rangeFilterValue = 8, RULE_range = 9, RULE_rangeStart = 10, RULE_rangeEnd = 11, 
		RULE_lower = 12, RULE_upper = 13, RULE_string = 14, RULE_negation = 15;
	public static readonly string[] ruleNames = {
		"searchPhrase", "phrase", "keyword", "filters", "attributeFilter", "rangeFilter", 
		"fieldName", "attributeFilterValue", "rangeFilterValue", "range", "rangeStart", 
		"rangeEnd", "lower", "upper", "string", "negation"
	};

	private static readonly string[] _LiteralNames = {
		null, "'!'", "':'", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "FD", "VD", "RD", "RangeStart", "RangeEnd", "String", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "SearchPhrase.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static SearchPhraseParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public SearchPhraseParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public SearchPhraseParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
	public partial class SearchPhraseContext : ParserRuleContext {
		public PhraseContext[] phrase() {
			return GetRuleContexts<PhraseContext>();
		}
		public PhraseContext phrase(int i) {
			return GetRuleContext<PhraseContext>(i);
		}
		public ITerminalNode[] WS() { return GetTokens(SearchPhraseParser.WS); }
		public ITerminalNode WS(int i) {
			return GetToken(SearchPhraseParser.WS, i);
		}
		public SearchPhraseContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_searchPhrase; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterSearchPhrase(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitSearchPhrase(this);
		}
	}

	[RuleVersion(0)]
	public SearchPhraseContext searchPhrase() {
		SearchPhraseContext _localctx = new SearchPhraseContext(Context, State);
		EnterRule(_localctx, 0, RULE_searchPhrase);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 35;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==WS) {
				{
				{
				State = 32; Match(WS);
				}
				}
				State = 37;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 38; phrase();
			State = 43;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					State = 39; Match(WS);
					State = 40; phrase();
					}
					} 
				}
				State = 45;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,1,Context);
			}
			State = 49;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==WS) {
				{
				{
				State = 46; Match(WS);
				}
				}
				State = 51;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PhraseContext : ParserRuleContext {
		public KeywordContext keyword() {
			return GetRuleContext<KeywordContext>(0);
		}
		public FiltersContext filters() {
			return GetRuleContext<FiltersContext>(0);
		}
		public PhraseContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_phrase; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterPhrase(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitPhrase(this);
		}
	}

	[RuleVersion(0)]
	public PhraseContext phrase() {
		PhraseContext _localctx = new PhraseContext(Context, State);
		EnterRule(_localctx, 2, RULE_phrase);
		try {
			State = 54;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 52; keyword();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 53; filters();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class KeywordContext : ParserRuleContext {
		public ITerminalNode String() { return GetToken(SearchPhraseParser.String, 0); }
		public KeywordContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_keyword; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterKeyword(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitKeyword(this);
		}
	}

	[RuleVersion(0)]
	public KeywordContext keyword() {
		KeywordContext _localctx = new KeywordContext(Context, State);
		EnterRule(_localctx, 4, RULE_keyword);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 56; Match(String);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FiltersContext : ParserRuleContext {
		public AttributeFilterContext attributeFilter() {
			return GetRuleContext<AttributeFilterContext>(0);
		}
		public RangeFilterContext rangeFilter() {
			return GetRuleContext<RangeFilterContext>(0);
		}
		public NegationContext negation() {
			return GetRuleContext<NegationContext>(0);
		}
		public FiltersContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_filters; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterFilters(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitFilters(this);
		}
	}

	[RuleVersion(0)]
	public FiltersContext filters() {
		FiltersContext _localctx = new FiltersContext(Context, State);
		EnterRule(_localctx, 6, RULE_filters);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 59;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__0) {
				{
				State = 58; negation();
				}
			}

			State = 63;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
			case 1:
				{
				State = 61; attributeFilter();
				}
				break;
			case 2:
				{
				State = 62; rangeFilter();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AttributeFilterContext : ParserRuleContext {
		public FieldNameContext fieldName() {
			return GetRuleContext<FieldNameContext>(0);
		}
		public ITerminalNode FD() { return GetToken(SearchPhraseParser.FD, 0); }
		public AttributeFilterValueContext attributeFilterValue() {
			return GetRuleContext<AttributeFilterValueContext>(0);
		}
		public AttributeFilterContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_attributeFilter; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterAttributeFilter(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitAttributeFilter(this);
		}
	}

	[RuleVersion(0)]
	public AttributeFilterContext attributeFilter() {
		AttributeFilterContext _localctx = new AttributeFilterContext(Context, State);
		EnterRule(_localctx, 8, RULE_attributeFilter);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 65; fieldName();
			State = 66; Match(FD);
			State = 67; attributeFilterValue();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RangeFilterContext : ParserRuleContext {
		public FieldNameContext fieldName() {
			return GetRuleContext<FieldNameContext>(0);
		}
		public ITerminalNode FD() { return GetToken(SearchPhraseParser.FD, 0); }
		public RangeFilterValueContext rangeFilterValue() {
			return GetRuleContext<RangeFilterValueContext>(0);
		}
		public RangeFilterContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rangeFilter; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterRangeFilter(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitRangeFilter(this);
		}
	}

	[RuleVersion(0)]
	public RangeFilterContext rangeFilter() {
		RangeFilterContext _localctx = new RangeFilterContext(Context, State);
		EnterRule(_localctx, 10, RULE_rangeFilter);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 69; fieldName();
			State = 70; Match(FD);
			State = 71; rangeFilterValue();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FieldNameContext : ParserRuleContext {
		public ITerminalNode String() { return GetToken(SearchPhraseParser.String, 0); }
		public FieldNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_fieldName; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterFieldName(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitFieldName(this);
		}
	}

	[RuleVersion(0)]
	public FieldNameContext fieldName() {
		FieldNameContext _localctx = new FieldNameContext(Context, State);
		EnterRule(_localctx, 12, RULE_fieldName);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 73; Match(String);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AttributeFilterValueContext : ParserRuleContext {
		public StringContext[] @string() {
			return GetRuleContexts<StringContext>();
		}
		public StringContext @string(int i) {
			return GetRuleContext<StringContext>(i);
		}
		public ITerminalNode[] VD() { return GetTokens(SearchPhraseParser.VD); }
		public ITerminalNode VD(int i) {
			return GetToken(SearchPhraseParser.VD, i);
		}
		public AttributeFilterValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_attributeFilterValue; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterAttributeFilterValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitAttributeFilterValue(this);
		}
	}

	[RuleVersion(0)]
	public AttributeFilterValueContext attributeFilterValue() {
		AttributeFilterValueContext _localctx = new AttributeFilterValueContext(Context, State);
		EnterRule(_localctx, 14, RULE_attributeFilterValue);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 75; @string();
			State = 80;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==VD) {
				{
				{
				State = 76; Match(VD);
				State = 77; @string();
				}
				}
				State = 82;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RangeFilterValueContext : ParserRuleContext {
		public RangeContext[] range() {
			return GetRuleContexts<RangeContext>();
		}
		public RangeContext range(int i) {
			return GetRuleContext<RangeContext>(i);
		}
		public ITerminalNode[] VD() { return GetTokens(SearchPhraseParser.VD); }
		public ITerminalNode VD(int i) {
			return GetToken(SearchPhraseParser.VD, i);
		}
		public RangeFilterValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rangeFilterValue; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterRangeFilterValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitRangeFilterValue(this);
		}
	}

	[RuleVersion(0)]
	public RangeFilterValueContext rangeFilterValue() {
		RangeFilterValueContext _localctx = new RangeFilterValueContext(Context, State);
		EnterRule(_localctx, 16, RULE_rangeFilterValue);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 83; range();
			State = 88;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==VD) {
				{
				{
				State = 84; Match(VD);
				State = 85; range();
				}
				}
				State = 90;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RangeContext : ParserRuleContext {
		public RangeStartContext rangeStart() {
			return GetRuleContext<RangeStartContext>(0);
		}
		public ITerminalNode RD() { return GetToken(SearchPhraseParser.RD, 0); }
		public RangeEndContext rangeEnd() {
			return GetRuleContext<RangeEndContext>(0);
		}
		public ITerminalNode[] WS() { return GetTokens(SearchPhraseParser.WS); }
		public ITerminalNode WS(int i) {
			return GetToken(SearchPhraseParser.WS, i);
		}
		public LowerContext lower() {
			return GetRuleContext<LowerContext>(0);
		}
		public UpperContext upper() {
			return GetRuleContext<UpperContext>(0);
		}
		public RangeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_range; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterRange(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitRange(this);
		}
	}

	[RuleVersion(0)]
	public RangeContext range() {
		RangeContext _localctx = new RangeContext(Context, State);
		EnterRule(_localctx, 18, RULE_range);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 91; rangeStart();
			State = 95;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,8,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					State = 92; Match(WS);
					}
					} 
				}
				State = 97;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,8,Context);
			}
			State = 99;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==String) {
				{
				State = 98; lower();
				}
			}

			State = 104;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==WS) {
				{
				{
				State = 101; Match(WS);
				}
				}
				State = 106;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 107; Match(RD);
			State = 111;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,11,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					State = 108; Match(WS);
					}
					} 
				}
				State = 113;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,11,Context);
			}
			State = 115;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==String) {
				{
				State = 114; upper();
				}
			}

			State = 120;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==WS) {
				{
				{
				State = 117; Match(WS);
				}
				}
				State = 122;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 123; rangeEnd();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RangeStartContext : ParserRuleContext {
		public ITerminalNode RangeStart() { return GetToken(SearchPhraseParser.RangeStart, 0); }
		public RangeStartContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rangeStart; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterRangeStart(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitRangeStart(this);
		}
	}

	[RuleVersion(0)]
	public RangeStartContext rangeStart() {
		RangeStartContext _localctx = new RangeStartContext(Context, State);
		EnterRule(_localctx, 20, RULE_rangeStart);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 125; Match(RangeStart);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class RangeEndContext : ParserRuleContext {
		public ITerminalNode RangeEnd() { return GetToken(SearchPhraseParser.RangeEnd, 0); }
		public RangeEndContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rangeEnd; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterRangeEnd(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitRangeEnd(this);
		}
	}

	[RuleVersion(0)]
	public RangeEndContext rangeEnd() {
		RangeEndContext _localctx = new RangeEndContext(Context, State);
		EnterRule(_localctx, 22, RULE_rangeEnd);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 127; Match(RangeEnd);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LowerContext : ParserRuleContext {
		public ITerminalNode String() { return GetToken(SearchPhraseParser.String, 0); }
		public LowerContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_lower; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterLower(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitLower(this);
		}
	}

	[RuleVersion(0)]
	public LowerContext lower() {
		LowerContext _localctx = new LowerContext(Context, State);
		EnterRule(_localctx, 24, RULE_lower);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 129; Match(String);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class UpperContext : ParserRuleContext {
		public ITerminalNode String() { return GetToken(SearchPhraseParser.String, 0); }
		public UpperContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_upper; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterUpper(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitUpper(this);
		}
	}

	[RuleVersion(0)]
	public UpperContext upper() {
		UpperContext _localctx = new UpperContext(Context, State);
		EnterRule(_localctx, 26, RULE_upper);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 131; Match(String);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StringContext : ParserRuleContext {
		public ITerminalNode String() { return GetToken(SearchPhraseParser.String, 0); }
		public StringContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_string; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterString(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitString(this);
		}
	}

	[RuleVersion(0)]
	public StringContext @string() {
		StringContext _localctx = new StringContext(Context, State);
		EnterRule(_localctx, 28, RULE_string);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 133; Match(String);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NegationContext : ParserRuleContext {
		public NegationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_negation; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.EnterNegation(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISearchPhraseListener typedListener = listener as ISearchPhraseListener;
			if (typedListener != null) typedListener.ExitNegation(this);
		}
	}

	[RuleVersion(0)]
	public NegationContext negation() {
		NegationContext _localctx = new NegationContext(Context, State);
		EnterRule(_localctx, 30, RULE_negation);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 135; Match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\n', '\x8C', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', '\t', 
		'\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x3', '\x2', '\a', '\x2', '$', '\n', '\x2', '\f', 
		'\x2', '\xE', '\x2', '\'', '\v', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\a', '\x2', ',', '\n', '\x2', '\f', '\x2', '\xE', '\x2', '/', 
		'\v', '\x2', '\x3', '\x2', '\a', '\x2', '\x32', '\n', '\x2', '\f', '\x2', 
		'\xE', '\x2', '\x35', '\v', '\x2', '\x3', '\x3', '\x3', '\x3', '\x5', 
		'\x3', '\x39', '\n', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', 
		'\x5', '\x5', '>', '\n', '\x5', '\x3', '\x5', '\x3', '\x5', '\x5', '\x5', 
		'\x42', '\n', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', 
		'\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\a', '\t', 'Q', '\n', 
		'\t', '\f', '\t', '\xE', '\t', 'T', '\v', '\t', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\a', '\n', 'Y', '\n', '\n', '\f', '\n', '\xE', '\n', '\\', 
		'\v', '\n', '\x3', '\v', '\x3', '\v', '\a', '\v', '`', '\n', '\v', '\f', 
		'\v', '\xE', '\v', '\x63', '\v', '\v', '\x3', '\v', '\x5', '\v', '\x66', 
		'\n', '\v', '\x3', '\v', '\a', '\v', 'i', '\n', '\v', '\f', '\v', '\xE', 
		'\v', 'l', '\v', '\v', '\x3', '\v', '\x3', '\v', '\a', '\v', 'p', '\n', 
		'\v', '\f', '\v', '\xE', '\v', 's', '\v', '\v', '\x3', '\v', '\x5', '\v', 
		'v', '\n', '\v', '\x3', '\v', '\a', '\v', 'y', '\n', '\v', '\f', '\v', 
		'\xE', '\v', '|', '\v', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', 
		'\f', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x2', '\x2', '\x12', '\x2', '\x4', '\x6', '\b', '\n', 
		'\f', '\xE', '\x10', '\x12', '\x14', '\x16', '\x18', '\x1A', '\x1C', '\x1E', 
		' ', '\x2', '\x2', '\x2', '\x89', '\x2', '%', '\x3', '\x2', '\x2', '\x2', 
		'\x4', '\x38', '\x3', '\x2', '\x2', '\x2', '\x6', ':', '\x3', '\x2', '\x2', 
		'\x2', '\b', '=', '\x3', '\x2', '\x2', '\x2', '\n', '\x43', '\x3', '\x2', 
		'\x2', '\x2', '\f', 'G', '\x3', '\x2', '\x2', '\x2', '\xE', 'K', '\x3', 
		'\x2', '\x2', '\x2', '\x10', 'M', '\x3', '\x2', '\x2', '\x2', '\x12', 
		'U', '\x3', '\x2', '\x2', '\x2', '\x14', ']', '\x3', '\x2', '\x2', '\x2', 
		'\x16', '\x7F', '\x3', '\x2', '\x2', '\x2', '\x18', '\x81', '\x3', '\x2', 
		'\x2', '\x2', '\x1A', '\x83', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x85', 
		'\x3', '\x2', '\x2', '\x2', '\x1E', '\x87', '\x3', '\x2', '\x2', '\x2', 
		' ', '\x89', '\x3', '\x2', '\x2', '\x2', '\"', '$', '\a', '\n', '\x2', 
		'\x2', '#', '\"', '\x3', '\x2', '\x2', '\x2', '$', '\'', '\x3', '\x2', 
		'\x2', '\x2', '%', '#', '\x3', '\x2', '\x2', '\x2', '%', '&', '\x3', '\x2', 
		'\x2', '\x2', '&', '(', '\x3', '\x2', '\x2', '\x2', '\'', '%', '\x3', 
		'\x2', '\x2', '\x2', '(', '-', '\x5', '\x4', '\x3', '\x2', ')', '*', '\a', 
		'\n', '\x2', '\x2', '*', ',', '\x5', '\x4', '\x3', '\x2', '+', ')', '\x3', 
		'\x2', '\x2', '\x2', ',', '/', '\x3', '\x2', '\x2', '\x2', '-', '+', '\x3', 
		'\x2', '\x2', '\x2', '-', '.', '\x3', '\x2', '\x2', '\x2', '.', '\x33', 
		'\x3', '\x2', '\x2', '\x2', '/', '-', '\x3', '\x2', '\x2', '\x2', '\x30', 
		'\x32', '\a', '\n', '\x2', '\x2', '\x31', '\x30', '\x3', '\x2', '\x2', 
		'\x2', '\x32', '\x35', '\x3', '\x2', '\x2', '\x2', '\x33', '\x31', '\x3', 
		'\x2', '\x2', '\x2', '\x33', '\x34', '\x3', '\x2', '\x2', '\x2', '\x34', 
		'\x3', '\x3', '\x2', '\x2', '\x2', '\x35', '\x33', '\x3', '\x2', '\x2', 
		'\x2', '\x36', '\x39', '\x5', '\x6', '\x4', '\x2', '\x37', '\x39', '\x5', 
		'\b', '\x5', '\x2', '\x38', '\x36', '\x3', '\x2', '\x2', '\x2', '\x38', 
		'\x37', '\x3', '\x2', '\x2', '\x2', '\x39', '\x5', '\x3', '\x2', '\x2', 
		'\x2', ':', ';', '\a', '\t', '\x2', '\x2', ';', '\a', '\x3', '\x2', '\x2', 
		'\x2', '<', '>', '\x5', ' ', '\x11', '\x2', '=', '<', '\x3', '\x2', '\x2', 
		'\x2', '=', '>', '\x3', '\x2', '\x2', '\x2', '>', '\x41', '\x3', '\x2', 
		'\x2', '\x2', '?', '\x42', '\x5', '\n', '\x6', '\x2', '@', '\x42', '\x5', 
		'\f', '\a', '\x2', '\x41', '?', '\x3', '\x2', '\x2', '\x2', '\x41', '@', 
		'\x3', '\x2', '\x2', '\x2', '\x42', '\t', '\x3', '\x2', '\x2', '\x2', 
		'\x43', '\x44', '\x5', '\xE', '\b', '\x2', '\x44', '\x45', '\a', '\x4', 
		'\x2', '\x2', '\x45', '\x46', '\x5', '\x10', '\t', '\x2', '\x46', '\v', 
		'\x3', '\x2', '\x2', '\x2', 'G', 'H', '\x5', '\xE', '\b', '\x2', 'H', 
		'I', '\a', '\x4', '\x2', '\x2', 'I', 'J', '\x5', '\x12', '\n', '\x2', 
		'J', '\r', '\x3', '\x2', '\x2', '\x2', 'K', 'L', '\a', '\t', '\x2', '\x2', 
		'L', '\xF', '\x3', '\x2', '\x2', '\x2', 'M', 'R', '\x5', '\x1E', '\x10', 
		'\x2', 'N', 'O', '\a', '\x5', '\x2', '\x2', 'O', 'Q', '\x5', '\x1E', '\x10', 
		'\x2', 'P', 'N', '\x3', '\x2', '\x2', '\x2', 'Q', 'T', '\x3', '\x2', '\x2', 
		'\x2', 'R', 'P', '\x3', '\x2', '\x2', '\x2', 'R', 'S', '\x3', '\x2', '\x2', 
		'\x2', 'S', '\x11', '\x3', '\x2', '\x2', '\x2', 'T', 'R', '\x3', '\x2', 
		'\x2', '\x2', 'U', 'Z', '\x5', '\x14', '\v', '\x2', 'V', 'W', '\a', '\x5', 
		'\x2', '\x2', 'W', 'Y', '\x5', '\x14', '\v', '\x2', 'X', 'V', '\x3', '\x2', 
		'\x2', '\x2', 'Y', '\\', '\x3', '\x2', '\x2', '\x2', 'Z', 'X', '\x3', 
		'\x2', '\x2', '\x2', 'Z', '[', '\x3', '\x2', '\x2', '\x2', '[', '\x13', 
		'\x3', '\x2', '\x2', '\x2', '\\', 'Z', '\x3', '\x2', '\x2', '\x2', ']', 
		'\x61', '\x5', '\x16', '\f', '\x2', '^', '`', '\a', '\n', '\x2', '\x2', 
		'_', '^', '\x3', '\x2', '\x2', '\x2', '`', '\x63', '\x3', '\x2', '\x2', 
		'\x2', '\x61', '_', '\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\x3', 
		'\x2', '\x2', '\x2', '\x62', '\x65', '\x3', '\x2', '\x2', '\x2', '\x63', 
		'\x61', '\x3', '\x2', '\x2', '\x2', '\x64', '\x66', '\x5', '\x1A', '\xE', 
		'\x2', '\x65', '\x64', '\x3', '\x2', '\x2', '\x2', '\x65', '\x66', '\x3', 
		'\x2', '\x2', '\x2', '\x66', 'j', '\x3', '\x2', '\x2', '\x2', 'g', 'i', 
		'\a', '\n', '\x2', '\x2', 'h', 'g', '\x3', '\x2', '\x2', '\x2', 'i', 'l', 
		'\x3', '\x2', '\x2', '\x2', 'j', 'h', '\x3', '\x2', '\x2', '\x2', 'j', 
		'k', '\x3', '\x2', '\x2', '\x2', 'k', 'm', '\x3', '\x2', '\x2', '\x2', 
		'l', 'j', '\x3', '\x2', '\x2', '\x2', 'm', 'q', '\a', '\x6', '\x2', '\x2', 
		'n', 'p', '\a', '\n', '\x2', '\x2', 'o', 'n', '\x3', '\x2', '\x2', '\x2', 
		'p', 's', '\x3', '\x2', '\x2', '\x2', 'q', 'o', '\x3', '\x2', '\x2', '\x2', 
		'q', 'r', '\x3', '\x2', '\x2', '\x2', 'r', 'u', '\x3', '\x2', '\x2', '\x2', 
		's', 'q', '\x3', '\x2', '\x2', '\x2', 't', 'v', '\x5', '\x1C', '\xF', 
		'\x2', 'u', 't', '\x3', '\x2', '\x2', '\x2', 'u', 'v', '\x3', '\x2', '\x2', 
		'\x2', 'v', 'z', '\x3', '\x2', '\x2', '\x2', 'w', 'y', '\a', '\n', '\x2', 
		'\x2', 'x', 'w', '\x3', '\x2', '\x2', '\x2', 'y', '|', '\x3', '\x2', '\x2', 
		'\x2', 'z', 'x', '\x3', '\x2', '\x2', '\x2', 'z', '{', '\x3', '\x2', '\x2', 
		'\x2', '{', '}', '\x3', '\x2', '\x2', '\x2', '|', 'z', '\x3', '\x2', '\x2', 
		'\x2', '}', '~', '\x5', '\x18', '\r', '\x2', '~', '\x15', '\x3', '\x2', 
		'\x2', '\x2', '\x7F', '\x80', '\a', '\a', '\x2', '\x2', '\x80', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x81', '\x82', '\a', '\b', '\x2', '\x2', 
		'\x82', '\x19', '\x3', '\x2', '\x2', '\x2', '\x83', '\x84', '\a', '\t', 
		'\x2', '\x2', '\x84', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x85', '\x86', 
		'\a', '\t', '\x2', '\x2', '\x86', '\x1D', '\x3', '\x2', '\x2', '\x2', 
		'\x87', '\x88', '\a', '\t', '\x2', '\x2', '\x88', '\x1F', '\x3', '\x2', 
		'\x2', '\x2', '\x89', '\x8A', '\a', '\x3', '\x2', '\x2', '\x8A', '!', 
		'\x3', '\x2', '\x2', '\x2', '\x10', '%', '-', '\x33', '\x38', '=', '\x41', 
		'R', 'Z', '\x61', '\x65', 'j', 'q', 'u', 'z',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace VirtoCommerce.CoreModule.Data.Search.SearchPhraseParsing.Antlr