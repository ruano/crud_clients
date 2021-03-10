import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5000/api",
  headers: {
    "Content-Type": "application/json"
  }
});

export default {
  list() {
    return api.get("/customers");
  },
  add(data) {
    return api.post("/customers", data);
  },
  get(id) {
    return api.get(`/customers/${id}`);
  },
  update(id, data) {
    return api.put(`/customers/${id}`, data);
  },
  remove(id) {
    return api.delete(`/customers/${id}`);
  }
};
