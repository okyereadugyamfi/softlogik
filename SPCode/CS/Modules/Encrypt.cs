using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;




namespace SoftLogik.Win
{
	public enum HashTypeEnum
	{
		htMD5 = 4
	}
	
	public enum EncryptAlgorithmsEnum
	{
		eaRC4 = 1,
		eaRC2,
		eaDES,
		ea3DES,
		ea3DES112
	}
	
	public sealed class SPEncrypt
	{
		
		public static byte[] EncryptByte(EncryptAlgorithmsEnum Algorithm, string SourceText, bool CaseSensitive, string Key, string Salt)
		{
			CryptKci.clsCryptoAPI objCrypto = new CryptKci.clsCryptoAPI();
			
			try
			{
				objCrypto.InputData = objCrypto.StringToByteArray((object) SourceText);
				objCrypto.EnhancedProvider = true;
				objCrypto.Password = objCrypto.StringToByteArray((object) Key);
				objCrypto.Encrypt(((short) HashTypeEnum.htMD5), ((short) Algorithm));
				return objCrypto.OutputData;
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				objCrypto = null;
			}
			
		}
		
		public static string EncryptString(EncryptAlgorithmsEnum Algorithm, string SourceText, bool CaseSensitive, string Key, string Salt)
		{
			CryptKci.clsCryptoAPI objCrypto = new CryptKci.clsCryptoAPI();
			
			try
			{
				objCrypto.InputData = objCrypto.StringToByteArray(System.Convert.ToString(SourceText));
				objCrypto.EnhancedProvider = true;
				objCrypto.Password = objCrypto.StringToByteArray(System.Convert.ToString(Key));
				objCrypto.Encrypt(((short) HashTypeEnum.htMD5), ((short) Algorithm));
				return objCrypto.ByteArrayToString(objCrypto.OutputData);
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
			finally
			{
				objCrypto = null;
			}
			
		}
		public static byte[] ToByte(string SourceString)
		{
			CryptKci.clsCryptoAPI objCrypto = new CryptKci.clsCryptoAPI();
			
			return objCrypto.StringToByteArray(System.Convert.ToString(SourceString));
//			objCrypto = null;
			
		}
		
		public static string CreateSaltValue(int ReturnLength, bool UseLettersNumbersOnly)
		{
			CryptKci.clsCryptoAPI objCrypto = new CryptKci.clsCryptoAPI();
			
			return System.Convert.ToString(objCrypto.CreateSaltValue(ref ReturnLength, ref UseLettersNumbersOnly));
//			objCrypto = null;
			
		}
	}
	
	
}
