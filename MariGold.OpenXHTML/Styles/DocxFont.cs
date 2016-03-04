﻿namespace MariGold.OpenXHTML
{
	using System;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Wordprocessing;
	
	internal static class DocxFont
	{
		internal const string fontFamily = "font-family";
		internal const string fontWeight = "font-weight";
		internal const string fontStyle = "font-style";
		internal const string textDecoration = "text-decoration";
		
		internal const string bold = "bold";
		internal const string bolder = "bolder";
		internal const string italic = "italic";
		internal const string oblique = "oblique";
		internal const string underLine = "underline";
		internal const string lineThrough = "line-through";
		
		internal static bool ApplyFontFamily(string styleName, string value, OpenXmlElement styleElement)
		{
			if (string.Compare(fontFamily, styleName, StringComparison.InvariantCultureIgnoreCase) == 0) 
			{
				styleElement.Append(new RunFonts() { Ascii = value });
				
				return true;
			}
			
			return false;
		}
		
		internal static bool ApplyFontWeight(string styleName, string value, OpenXmlElement styleElement)
		{
			if (string.Compare(fontWeight, styleName, StringComparison.InvariantCultureIgnoreCase) != 0) 
			{
				return false;
			}
			
			if (string.Compare(bold, value, StringComparison.InvariantCultureIgnoreCase) == 0 ||
			    string.Compare(bolder, value, StringComparison.InvariantCultureIgnoreCase) == 0) 
			{
				styleElement.Append(new Bold());
			}
			
			return true;
		}
		
		internal static bool ApplyFontItalic(string styleName, string value, OpenXmlElement styleElement)
		{
			if (string.Compare(fontStyle, styleName, StringComparison.InvariantCultureIgnoreCase) != 0) 
			{
				return false;
			}
			
			if (string.Compare(italic, value, StringComparison.InvariantCultureIgnoreCase) == 0 &&
			    string.Compare(oblique, value, StringComparison.InvariantCultureIgnoreCase) == 0) 
			{
				styleElement.Append(new Italic());
			}
			
			return true;
		}
		
		internal static bool ApplyTextDecoration(string styleName, string value, OpenXmlElement styleElement)
		{
			if (string.Compare(textDecoration, styleName, StringComparison.InvariantCultureIgnoreCase) != 0) 
			{
				return false;
			}
			
			if (string.Compare(value, underLine, StringComparison.InvariantCultureIgnoreCase) == 0) 
			{
				styleElement.Append(new Underline(){ Val = UnderlineValues.Single });
			}
			else if (string.Compare(value, lineThrough, StringComparison.InvariantCultureIgnoreCase) == 0) 
			{
				styleElement.Append(new Strike());
			}
			
			return true;
		}
		
		internal static void ApplyUnderline(OpenXmlElement styleElement)
		{
			styleElement.Append(new Underline(){ Val = UnderlineValues.Single });
		}
		
		internal static void ApplyFontItalic(OpenXmlElement styleElement)
		{
			styleElement.Append(new Italic());
		}
		
		internal static void ApplyBold(OpenXmlElement styleElement)
		{
			styleElement.Append(new Bold());
		}
		
		internal static void ApplyFont(int size, bool isBold, OpenXmlElement styleElement)
		{
			FontSize fontSize = new FontSize(){ Val = size.ToString() };
			
			if (isBold) 
			{
				styleElement.Append(new Bold());
			}
			
			styleElement.Append(fontSize);
		}
	}
}
