<template id="PaginationComponent">
    
</template>





<script>
    new Vue({
        data: {
            currentPage: 1,
            totalPages: 0,
            pageSize: 10,
            totalItems: 0,
        },
        method: {
            getPagedData : async function() {
                try {
                    let queryParams = new URLSearchParams();

                    if (this.currentPage) queryParams.append("page", this.currentPage);
                    if (this.pageSize) queryParams.append("pageSize", this.pageSize);

                    const response = await axios.get('/CarWithVueJs/GetPagedData?' + queryParams.toString());

                    console.log(response.data.data);

                    this.filteredCars = response.data.data;
                    this.totalItems = response.data.totalItem;
                    this.totalPages = Math.ceil(this.totalItems / this.pageSize);
                }
                catch(error) {
                    console.error('Error fetching paged data:', error);
                }
            }
        }
    });
</script>