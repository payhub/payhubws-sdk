package com.payhub.ws.api;

import java.util.List;
import com.payhub.ws.model.Metadata;
import com.payhub.ws.model.VoidResponse;
import com.fasterxml.jackson.annotation.JsonInclude;

@JsonInclude(JsonInclude.Include.NON_NULL)  
public class LastVoidResponseInformation {
	private Metadata metadata;
    private String transaction_id;
    private VoidResponse lastVoidResponse;
    private String merchantOrganizationId;
    public Object _links;
    private List<Errors> errors;
    public String rowData;
    
	public Metadata getMetadata() {
		return metadata;
	}
	public void setMetadata(Metadata metadata) {
		this.metadata = metadata;
	}
	public String getTransaction_id() {
		return transaction_id;
	}
	public void setTransaction_id(String transaction_id) {
		this.transaction_id = transaction_id;
	}
	public VoidResponse getLastVoidResponse() {
		return lastVoidResponse;
	}
	public void setLastVoidResponse(VoidResponse lastVoidResponse) {
		this.lastVoidResponse = lastVoidResponse;
	}
	public String getMerchantOrganizationId() {
		return merchantOrganizationId;
	}
	public void setMerchantOrganizationId(String merchantOrganizationId) {
		this.merchantOrganizationId = merchantOrganizationId;
	}
	public Object get_links() {
		return _links;
	}
	public void set_links(Object _links) {
		this._links = _links;
	}
	public List<Errors> getErrors() {
		return errors;
	}
	public void setErrors(List<Errors> errors) {
		this.errors = errors;
	}
	public String getRowData() {
		return rowData;
	}
	public void setRowData(String rowData) {
		this.rowData = rowData;
	}
    
}
