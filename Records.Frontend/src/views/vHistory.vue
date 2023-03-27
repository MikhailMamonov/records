<template>
  <div>
    <div class="page-title">
      <h3>История записей</h3>
    </div>

    <v-loader v-if="loading" />

    <p v-else-if="!records.length">
      Записей пока нет
      <router-link to="/">Добавить новую запись</router-link>
    </p>
    <section v-else>
      <v-history-table
       :records="records"/>
    </section>
  </div>
</template>

<script>
import vLoader from "@/components/app/vLoader.vue";
import vHistoryTable from "@/components/vHistoryTable.vue";
import { mapActions } from "vuex";

export default {
  name: "v-history",
  data() {
    return {
      loading: true,

      records: [],
    };
  },
  components: {
    vLoader,
    vHistoryTable,
  },
  methods: {
    ...mapActions(["FETCH_CATEGORIES", "FETCH_RECORDS"]),
    setup(categories) {
        this.records = this.records.map((rec) => {
          return {
            ...rec,
            categoryName: categories.find((c) => c.id === rec.categoryId).name,
            typeClass: rec.type === "income" ? "green" : "red",
            typeText: rec.type === "income" ? "Доход" : "Расход",
          };
        })
    },
  },
  async mounted() {
    const categories = await this.FETCH_CATEGORIES();
    this.records = await this.FETCH_RECORDS();

    this.setup(categories);
    this.loading = false;
  },
};
</script>
