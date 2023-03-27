<template>
   <div class="row">
    <div class="col s12">
      <div class="row">
        <div class="input-field col s12">
          <i class="material-icons prefix">search</i>
          <input type="text"  v-model="searchQuery"  id="autocomplete-input" class="autocomplete">
          <label for="autocomplete-input">Search record</label>
        </div>
      </div>
    </div></div>
  <table>
    <thead>
      <tr>
        <th>#</th>
        <th>Сумма</th>
        <th>Дата</th>
        <th>Описание</th>
        <th>Категория</th>
        <th>Тип</th>
        <th>Открыть</th>
      </tr>
    </thead>

    <tbody>
      <tr v-for="(record, index) in resultQuery" :key="index">
        <td>{{ index + 1 }}</td>
        <td>{{ record.amount }}</td>
        <td>{{ $filters.dateFilter(record.creationDate, "datetime") }}</td>
        <td>{{ record.description }}</td>
        <td>{{ record.categoryName }}</td>
        <td>
          <span class="white-text badge" :class="[record.typeClass]">{{
            record.typeText
          }}</span>
        </td>
        <td>
          <button
            class="btn-small btn"
            @click="$router.push('/detail/' + record.id)"
            v-tooltip="'Посмотреть запись'"
          >
            <i class="material-icons">open_in_new</i>
          </button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "v-history-table",
  data() {
    return {
        searchQuery:null,
    }
  },
  computed:{
     resultQuery() {
      if (this.searchQuery) {
        return this.records.filter(item => {
          return this.searchQuery
            .toLowerCase()
            .split(" ")
            .every(v => item.description.toLowerCase().includes(v));
        });
      } else {
        return this.records;
      }
  }},
  props: {
    records: {
      required: true,
      type: Array,
      default() {
        return [];
      },
    },
  },
};
</script>
