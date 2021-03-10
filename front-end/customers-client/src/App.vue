<template>
  <div id="app">
    <div class="m-3">
      <div class="row">
        <div class="col-md-6">
          <h3>Cadastro de Clientes</h3>
        </div>
        <div class="col-md-6">
          <b-button variant="primary" @click="openModal(0)">Novo</b-button>
        </div>
      </div>
      <br />
      <div class="row">
        <div class="col-md-12">
          <b-table
            id="clientsTable"
            bordered
            outlined
            striped
            hover
            head-variant="dark"
            :items="getCustomers"
            :fields="fields"
          >
            <template #cell(actions)="row">
              <i
                class="las la-edit"
                style="font-size: 24px"
                @click="openModal(row.item.id)"
              ></i>
              <i
                class="las la-trash-alt"
                style="font-size: 24px"
                @click="remove(row.item.id)"
              ></i>
            </template>
          </b-table>
        </div>
      </div>
    </div>
    <CustomerModal
      ref="customerModal"
      :onSave="reloadTable"
      :id="id"
    ></CustomerModal>
  </div>
</template>

<script>
import CustomerService from "./services/customer.service";
import CustomerModal from "./CustomerModal";

export default {
  name: "App",
  components: {
    CustomerModal
  },
  data() {
    return {
      id: 0,
      fields: [
        { key: "id", label: "Id" },
        { key: "name", label: "Nome" },
        { key: "age", label: "Idade" },
        { key: "actions", label: "Ações" }
      ]
    };
  },
  methods: {
    async getCustomers() {
      return await CustomerService.list().then(response => {
        return response.data;
      });
    },
    openModal(id) {
      this.id = id;
      this.$refs.customerModal.show();
    },
    reloadTable() {
      this.$root.$emit("bv::refresh::table", "clientsTable");
    },
    async remove(id) {
      await CustomerService.remove(id);
      this.reloadTable();
    }
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
