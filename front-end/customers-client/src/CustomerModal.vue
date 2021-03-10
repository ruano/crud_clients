<template>
  <b-modal
    v-model="modalShow"
    centered
    @ok="save"
    @shown="onOpen"
    @hidden="onClose"
    :title="id === 0 ? 'Novo' : 'Editar'"
  >
    <div class="row">
      <div class="col-md-12">
        <label>Nome</label>
        <input type="text" v-model="name" />
      </div>
      <div class="col-md-12">
        <label>Idade</label>
        <input type="number" v-model="age" />
      </div>
    </div>
    <div class="row" v-if="errorMessage">
      <div class="col-md-12">
        <p style="color: red">{{ errorMessage }}</p>
      </div>
    </div>
  </b-modal>
</template>

<script>
import CustomerService from "./services/customer.service";

export default {
  props: {
    onSave: { type: Function, required: true },
    id: { type: Number, required: true }
  },
  data() {
    return {
      modalShow: false,

      name: "",
      age: "",

      errorMessage: ""
    };
  },
  methods: {
    show() {
      this.modalShow = true;
    },
    async save(evt) {
      evt.preventDefault(); // It will prevent modal dismiss

      if (this.name === "") {
        this.errorMessage = "Informe o nome";
        return;
      }

      if (this.age === "") {
        this.errorMessage = "Informe a idade";
        return;
      }

      await this.sendRequest({ name: this.name, age: this.age }).then(
        () => {
          this.onSave();
          this.modalShow = false;
        },
        error => {
          this.errorMessage = error.response.data;
        }
      );
    },
    async sendRequest() {
      if (this.id === 0) {
        return await CustomerService.add({ name: this.name, age: this.age });
      } else {
        return await CustomerService.update(this.id, {
          name: this.name,
          age: this.age
        });
      }
    },
    async onOpen() {
      if (this.id !== 0) {
        await CustomerService.get(this.id).then(response => {
          this.name = response.data.name;
          this.age = response.data.age;
        });
      }
    },
    onClose() {
      this.name = "";
      this.age = "";
      this.errorMessage = "";
    }
  }
};
</script>

<style></style>
