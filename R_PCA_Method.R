'reading the Data'

csv.data <- read.csv(file.choose())

'PCA'

PcaRes <- princomp(csv.data, cor=TRUE)

'sparse Pca'

SPcaRes <-nsprcomp(csv.data, scale. = TRUE, nneg = FALSE)