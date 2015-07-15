package com.payhub.ws.api;

import java.util.List;

import com.payhub.ws.model.Metadata;
import com.payhub.ws.model.VerifyResponse;

public class VerfyResponseInformation {
	private Metadata metadata;
	private VerifyResponse verifyResponse;
	private Object _links;
	private List<Errors> errors;
	private String rowData;
	public Metadata getMetadata() {
		return metadata;
	}
	public void setMetadata(Metadata metadata) {
		this.metadata = metadata;
	}
	public VerifyResponse getVerifyResponse() {
		return verifyResponse;
	}
	public void setVerifyResponse(VerifyResponse verifyResponse) {
		this.verifyResponse = verifyResponse;
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
