namespace PayHubWS.payhub.ws.model
{
    ///  @author Agustin Breit 
    /// 
	public class BillForSale : Bill
	{
		private static readonly long serialVersionUID = 2865435483666149222L;

		///  Copied from the gateway class: issuer/processor/tsys/authrequest/TsysRequestBuilder.java 
		///  1 AN - Account Data Source 
		///  X Manually keyed, Track one capable 
		///  T Manually keyed, Track two capable 
		///  @ Manually keyed, terminal has no card reading capability 
		///  D Full magnetic stripe read and transmit, Track two 
		///  H Full magnetic stripe read and transmit, Track one 
		///   
		///  Z tokenized card 
		///  E Encrypted swipe track data. (added 04/2015) 
		/// 
		private string account_data_source = "T";


	}

}

