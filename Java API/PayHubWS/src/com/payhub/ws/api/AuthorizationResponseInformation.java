package com.payhub.ws.api;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.payhub.ws.model.AuthOnlyResponse;

@JsonInclude(JsonInclude.Include.NON_NULL)  
public class AuthorizationResponseInformation {
    private AuthOnlyResponse authOnlyResponse;    
    private Object _links;
    private List<Errors> errors;  
    private String rowData;
    private Object metaData;
	public String getMetaData() {
		return (String) metaData;
	}
	public void setMetaData(Object metadata) {
		this.metaData = metadata;
	}

	public AuthOnlyResponse getAuthOnlyResponse() {
		return authOnlyResponse;
	}

	public void setAuthOnlyResponse(AuthOnlyResponse authOnlyResponse) {
		this.authOnlyResponse = authOnlyResponse;
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
