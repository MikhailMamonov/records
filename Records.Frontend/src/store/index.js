import category from "./category";
import { createStore } from "vuex";
import record from "./record";

export default createStore({
  state: {
    error: null,
  },
  getters: { ERROR: (s) => s.error },
  mutations: {
    setError(state, error) {
      state.error = error;
    },
    clearError(state) {
      state.error = null;
    },
  },
  actions: {
  },
  modules: {  category, record },
});
