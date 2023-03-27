import apiClient from "../http-common";

export default {
  state:{
    records: []
  },

  
  actions: {
    async CREATE_RECORD({ commit }, record) {
      try {
        return await apiClient.post(`/record`,record)
      } catch (e) {
        commit("setError", e);
        throw e;
      }
    },

    async FETCH_RECORDS({ commit }) {
      try {
        const data = (await apiClient.get(`/record`)).data;
        console.log(data)
        commit("SET_RECORDS", data.records)
      return data.records;
      } catch (e) {
        commit("setError", e);
        throw e;
      }
    },

  async FETCH_RECORD_BY_ID({ commit, state }, id) {
      try {
        const record = state.records.find(r => r.id ==id);
        return {...record,id}
      } catch (e) {
        commit("setError", e);
        throw e;
      }
    },

  },
  getters: {},
  mutations: {
    SET_RECORDS(state, records){
      state.records = records
    }
  },
};
