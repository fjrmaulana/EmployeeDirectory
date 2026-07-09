document.addEventListener("DOMContentLoaded", () => {
    // Menangkap elemen-elemen penting di halaman web
    const searchInput = document.getElementById("searchInput");
    const tableBody = document.getElementById("employeeTableBody");
    const btnPrev = document.getElementById("btnPrev");
    const btnNext = document.getElementById("btnNext");
    const alertContainer = document.getElementById("alertContainer");

    let employeeIdToDelete = null;
    let buttonToDeleteElement = null;
    // Inisialisasi modal Bootstrap menggunakan Vanilla JS murni
    const bootstrapModal = new bootstrap.Modal(document.getElementById('deleteConfirmModal'));

    let debounceTimeout = null;

    // ==========================================
    // 1. FUNGSI UTAMA: MENGAMBIL DATA DARI BACKEND (FETCH API)
    // ==========================================
    async function fnFetchEmployees(page, search) {
        try {
            // PERBAIKAN DI SINI: Pastikan rutenya tegas menembak /api/employees dengan huruf kecil
            const response = await fetch(`/api/employees?page=${page}&searchTerm=${encodeURIComponent(search)}`, {
                headers: { "X-Requested-With": "XMLHttpRequest" }
            });

            if (!response.ok) throw new Error("Gagal mengambil data terbaru dari server VPS.");

            const data = await response.json();

            // Memperbarui status halaman global (State Management)
            window.AppState.currentPage = data.currentPage;
            window.AppState.totalPages = data.totalPages;
            window.AppState.searchTerm = data.searchTerm;

            // Render ulang isi tabel dan tombol navigasi halaman
            fnRenderTable(data.employees);
            fnRenderPagination(data);
        } catch (error) {
            fnShowAlert(error.message, "danger");
        }
    }

    // ==========================================
    // 2. FUNGSI UNTUK MERENDER ULANG TABEL SECARA DINAMIS
    // ==========================================
    function fnRenderTable(employees) {
        tableBody.innerHTML = "";

        // Kondisi jika pencarian menghasilkan data kosong
        if (employees.length === 0) {
            tableBody.innerHTML = `
                <tr id="emptyStateRow">
                    <td colspan="7" class="text-center text-muted py-4">Tidak ada data karyawan ditemukan.</td>
                </tr>`;
            return;
        }

        // Menyusun baris demi baris HTML baru dari data JSON
        employees.forEach(emp => {
            const tr = document.createElement("tr");
            tr.id = `row-${emp.id}`;
            tr.innerHTML = `
                <td class="fw-semibold">${emp.fullName}</td>
                <td>${emp.email}</td>
                <td><span class="badge bg-secondary">${emp.department}</span></td>
                <td>${emp.jobTitle}</td>
                <td>${emp.hireDate}</td>
                <td class="text-success fw-bold">${emp.salary}</td>
                <td class="text-center">
                    <button class="btn btn-outline-danger btn-sm btn-delete" data-id="${emp.id}">Hapus</button>
                </td>
            `;
            tableBody.appendChild(tr);
        });
    }

    // ==========================================
    // 3. FUNGSI UNTUK MERENDER ULANG TOMBOL NAVIGASI PAGINATION
    // ==========================================
    function fnRenderPagination(data) {
        document.getElementById("txtTotalShowing").innerText = data.employees.length;
        document.getElementById("txtTotalRecords").innerText = data.totalRecords;
        document.getElementById("txtCurrentPage").innerText = data.currentPage;
        document.getElementById("txtTotalPages").innerText = data.totalPages;

        // Mengatur status Tombol Previous (Mundur)
        if (data.currentPage === 1) {
            btnPrev.classList.add("disabled");
            btnPrev.querySelector("button").setAttribute("data-page", 1);
        } else {
            btnPrev.classList.remove("disabled");
            btnPrev.querySelector("button").setAttribute("data-page", data.currentPage - 1);
        }

        // Mengatur status Tombol Next (Maju)
        if (data.currentPage === data.totalPages || data.totalPages === 0) {
            btnNext.classList.add("disabled");
            btnNext.querySelector("button").setAttribute("data-page", data.totalPages);
        } else {
            btnNext.classList.remove("disabled");
            btnNext.querySelector("button").setAttribute("data-page", data.currentPage + 1);
        }
    }

    // ==========================================
    // 4. FUNGSI UNTUK MEMBUKA MODAL DIALOG CUSTOM
    // ==========================================
    function fnOpenDeleteModal(buttonElement) {
        // Simpan ID dan elemen tombol sementara di memori global JS
        employeeIdToDelete = buttonElement.getAttribute("data-id");
        buttonToDeleteElement = buttonElement;

        // Cari nama karyawan di baris tabel yang sama untuk ditampilkan di teks modal
        const currentRow = document.getElementById(`row-${employeeIdToDelete}`);
        const employeeName = currentRow.querySelector("td").innerText;
        document.getElementById("deleteTargetName").innerText = employeeName;

        // Tampilkan modal ke layar menggunakan Vanilla JS Bootstrap API
        bootstrapModal.show();
    }

    // ==========================================
    // 4B. FUNGSI EKSEKUSI PENGHAPUSAN ASLI (FETCH DELETE)
    // ==========================================
    async function fnExecuteDelete() {
        if (!employeeIdToDelete || !buttonToDeleteElement) return;

        const btnConfirm = document.getElementById("btnConfirmDeleteAction");

        // Efek visual mengubah tombol di dalam modal menjadi "Deleting..."
        const originalBtnText = btnConfirm.innerText;
        btnConfirm.innerText = "Deleting...";
        btnConfirm.disabled = true;

        try {
            // Mengirim permintaan HTTP DELETE ke backend VPS
            const response = await fetch(`/api/employees/${employeeIdToDelete}`, {
                method: "DELETE"
            });

            if (response.status === 404) throw new Error("Data sudah tidak ada atau telah dihapus oleh pengguna lain.");
            if (response.status === 400) throw new Error("Permintaan penghapusan tidak valid.");
            if (!response.ok) throw new Error("Terjadi gangguan jaringan, gagal menghubungi server.");

            // JIKA SUKSES: Tutup modal dialognya terlebih dahulu
            bootstrapModal.hide();

            // Hapus elemen baris tabel secara instan dari layar tanpa reload halaman
            const targetRow = document.getElementById(`row-${employeeIdToDelete}`);
            if (targetRow) targetRow.remove();

            fnShowAlert("Data karyawan berhasil dihapus!", "success");

            // Ambil ulang data halaman saat ini agar angka counter tetap sinkron
            await fnFetchEmployees(window.AppState.currentPage, window.AppState.searchTerm);

        } catch (error) {
            fnShowAlert(error.message, "danger");
            bootstrapModal.hide();
        } finally {
            // Kembalikan status tombol konfirmasi modal ke semula
            btnConfirm.innerText = originalBtnText;
            btnConfirm.disabled = false;

            // Bersihkan memori penampung
            employeeIdToDelete = null;
            buttonToDeleteElement = null;
        }
    }

    // ==========================================
    // 5. FUNGSI UNTUK MENAMPILKAN BANNER NOTIFIKASI (ALERT)
    // ==========================================
    function fnShowAlert(message, type) {
        alertContainer.innerHTML = `
            <div class="alert alert-${type} alert-dismissible fade show shadow-sm" role="alert">
                ${message}
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        `;

        // Otomatis menghilangkan notifikasi setelah 4 detik agar UI tetap bersih
        setTimeout(() => {
            const activeAlert = alertContainer.querySelector(".alert");
            if (activeAlert) {
                activeAlert.classList.remove("show");
                setTimeout(() => activeAlert.remove(), 150);
            }
        }, 4000);
    }

    // ==========================================
    // 6. EVENT LISTENERS (PENGHUBUNG INTERAKSI USER)
    // ==========================================

    // A. Event Kolom Pencarian dengan Sistem Debounce (300md)
    searchInput.addEventListener("input", (e) => {
        clearTimeout(debounceTimeout);
        debounceTimeout = setTimeout(() => {
            const term = e.target.value;
            // Ketentuan Tugas: Setiap melakukan pencarian baru, wajib reset ke Halaman 1
            fnFetchEmployees(1, term);
        }, 300);
    });

    // B. Event Klik Tombol Pagination (Previous & Next) menggunakan Event Delegation
    document.getElementById("paginationControls").addEventListener("click", (e) => {
        const clickedButton = e.target.closest("button");
        if (!clickedButton) return;

        const targetPage = parseInt(clickedButton.getAttribute("data-page"));
        if (targetPage !== window.AppState.currentPage && targetPage > 0) {
            fnFetchEmployees(targetPage, window.AppState.searchTerm);
        }
    });

    // C. Event Klik Tombol Hapus (Event Delegation untuk elemen dinamis)
    tableBody.addEventListener("click", (e) => {
        if (e.target.classList.contains("btn-delete")) {
            fnOpenDeleteModal(e.target);
        }
    });

    document.getElementById("btnConfirmDeleteAction").addEventListener("click", () => {
        fnExecuteDelete();
    });

});
