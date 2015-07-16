package com.payhub.ws.api;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.payhub.ws.model.CaptureResponse;



@JsonInclude(JsonInclude.Include.NON_NULL)  
public class LastCaptureResponseInformation {
	
    private CaptureResponse lastCaptureResponse;
    public Object _links;
    private List<Errors> errors;
    public String rowData;
    private Object metaData;
	public String getMetaData() {
		return (String) metaData;
	}
	public void setMetaData(Object metadata) {
		this.metaData = metadata;
	}
	public CaptureResponse getLastCaptureResponse() {
		return lastCaptureResponse;
	}
	public void setLastCaptureResponse(CaptureResponse lastCaptureResponse) {
		this.lastCaptureResponse = lastCaptureResponse;
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
