import apiClient from "../http-common";

export default {
  state:{
    categories: []
  },
  actions: {

    async FETCH_CATEGORIES({ commit}) {
      try {
        const data = (await apiClient.get(`/category`)).data;
         console.log(data)
        commit("SET_CATEGORIES", data.categories);
        return data.categories;
      } catch (e) {
        commit("setError", e);
        throw e;
      }
    },

    async FETCH_CATEGORY_BY_ID({ commit, state }, id) {
      try {
        return state.categories.find(c => c.id ===id)
      } catch (e) {
        commit("setError", e);
        throw e;
      }
    },
  },
  getters: {
    
  },
  mutations: {
    SET_CATEGORIES(state,categories){
      state.categories = categories;
    }
  },
};
