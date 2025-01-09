import axios from "axios";
let API_URL = "http://localhost:5284/api";
export function callApi(endpoint, method = "GET", body) {
  const url = `${API_URL}${endpoint.startsWith("/") ? "" : "/"}${endpoint}`;

  return axios({
    method,
    url,
    data: body,
  }).catch((e) => {
    console.log(e);
  });
}

export function GET_ALL_PRODUCTS(endpoint) {
  return callApi(endpoint, "GET");
}
export function GET_PRODUCT_ID(endpoint, id) {
  return callApi(endpoint + "/" + id, "GET");
}
export function GET_PRODUCT_TAGS(endpoint, tagName) {
  return callApi(endpoint + "/tag/" + tagName, "GET");
}
export function GET_TAG_NAME(endpoint, tagName) {
  return callApi(endpoint + "/name/" + tagName, "GET");
}
export function POST_ADD_PRODUCT(endpoint, data) {
  return callApi(endpoint, "POST", data);
}
export async function PUT_EDIT_PRODUCT(endpoint, data) {
  console.log("data", data);
  console.log("endpoint", endpoint);
  const response = await callApi(endpoint, "PUT", data);
  console.log(response);
  return response;
}
export function DELETE_PRODUCT_ID(endpoint) {
  return callApi(endpoint, "DELETE");
}
export function DELETE_PRODUCT_TAG_ID(endpoint) {
  return callApi(endpoint, "DELETE");
}
export function GET_ALL_CATEGORIES(endpoint) {
  return callApi(endpoint, "GET");
}
//Servise TAG
export function GET_ALL_TAG(endpoint) {

  return callApi(endpoint, "GET");

}
export function GET_TAG_ID(endpoint, id) {

  return callApi(endpoint+"/"+id, "GET");

}
export function POST_ADD_TAG(endpoint, data) {

  return callApi(endpoint, "POST", data);

}
export function PUT_EDIT_TAG(endpoint, data) {

  return callApi(endpoint, "PUT", data);

}
export function DELETE_TAG_ID(endpoint) { 

  return callApi(endpoint, "DELETE");

}
export function uploadMultipleImages(endpoint, productId, isThumbnail, images) {
  const formData = new FormData();

  formData.append("ProductId", productId);
  formData.append("IsThumbnail", isThumbnail);

  images.forEach((image) => {
    formData.append("imageFiles", image);
  });

  return callApi(endpoint, "POST", formData);
}
export async function POST_ADD_CATEGORY(formData) {
  try {
    const response = await axios.post(
      "http://localhost:5284/api/Categories",
      formData
    );
    return response.data;
  } catch (error) {
    throw error;
  }
}
export async function PUT_EDIT_CATEGORY(id, formData) {
  try {
    const response = await axios.put(
      `http://localhost:5284/api/Categories/${id}`,
      formData
    );
    return response.data;
  } catch (error) {
    throw error;
  }
}
