<template>
  <div class="modal-overlay">
    <div class="modal">
      <h6>Are you sure you wish to delete {{movieToUpdate.name}}?</h6>
      <button type="submit" @click="confirmDelete">Confirm</button>
      <button @click="cancelModal">Cancel</button>
    </div>
    <div class="close">
    </div>
  </div>
</template>

<script>


export default {
  name: "confirmation-modal",

  methods: {
    deleteModal() {
        this.$emit("delete-modal");
    },
    cancelModal() {
        this.$emit("cancel-confirmation-modal");
    },
    confirmDelete() {
        this.$emit("confirm-cancellation");
    }   
},
props: {
    movieToUpdate: Object
}

}
  </script>

  <style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  background-color: #000000da;
}

.modal {
  text-align: center;
  background-color: white;
  height: 250px;
  width: 500px;
  margin-top: 10%;
  padding: 60px 0;
  border-radius: 20px;
}

h6 {
  font-weight: 500;
  font-size: 28px;
  margin: 20px 0;
}

button {
  background-color:#2e00ac9a;
  width: 150px;
  height: 40px;
  color: white;
  font-size: 14px;
  border-radius: 16px;
  margin-top: 50px;
}
.error {
  color: red;
}

label {
  display:block;
  padding-top: 10px;
  text-align: center;
}
</style>