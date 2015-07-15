package com.payhub.ws.api;

import java.util.List;
import com.payhub.ws.model.Metadata;
import com.payhub.ws.model.SaleResponse;
import com.fasterxml.jackson.annotation.JsonInclude;

@JsonInclude(JsonInclude.Include.NON_NULL) 
public class SaleResponseInformation {
	private Metadata metadata;
    private SaleResponse saleResponse;
    public Object _links;
    private List<Errors> errors;
    public String rowData;
	public Metadata getMetadata() {
		return metadata;
	}
	public void setMetadata(Metadata metadata) {
		this.metadata = metadata;
	}
	public SaleResponse getSaleResponse() {
		return saleResponse;
	}
	public void setSaleResponse(SaleResponse saleResponse) {
		this.saleResponse = saleResponse;
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
